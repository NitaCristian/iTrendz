using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using iTrendz.Api.Authentication;
using iTrendz.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace iTrendz.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(
    UserManager<User> userManager,
    RoleManager<IdentityRole<int>> roleManager,
    IConfiguration configuration,
    ILogger<AuthenticationController> logger)
    : ControllerBase
{
    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Register([FromBody] RegistrationModel model)
    {
        var existingUser = await userManager.FindByNameAsync(model.Username);
        if (existingUser != null)
            return Conflict("User already exists.");

        User newUser;
        switch (model.UserType)
        {
            case "Brand":
                newUser = new Brand()
                {
                    UserName = model.Username,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Description = model.Description
                };
                break;
            case "Influencer":
                newUser = new Influencer()
                {
                    UserName = model.Username,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Description = model.Description
                };
                break;
            default:
                return BadRequest("Invalid user type specified.");
        }

        var result = await userManager.CreateAsync(newUser, model.Password);

        if (!result.Succeeded)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Failed to create user: {string.Join(" ", result.Errors.Select(e => e.Description))}");
        }

        if (!await roleManager.RoleExistsAsync(model.UserType))
        {
            await roleManager.CreateAsync(new IdentityRole<int>(model.UserType));
        }

        await userManager.AddToRoleAsync(newUser, model.UserType);

        return Ok("User successfully created");
    }

    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        logger.LogInformation("Login called");

        var user = await userManager.FindByNameAsync(model.Username);

        if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
            return Unauthorized();

        JwtSecurityToken token = GenerateJwt(model.Username);

        var refreshToken = GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiry = DateTime.UtcNow.AddMinutes(1);

        await userManager.UpdateAsync(user);

        logger.LogInformation("Login succeeded");

        return Ok(new LoginResponse
        {
            JwtToken = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo,
            RefreshToken = refreshToken
        });
    }

    [HttpPost("Refresh")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Refresh([FromBody] RefreshModel model)
    {
        logger.LogInformation("Refresh called");

        var principal = GetPrincipalFromExpiredToken(model.AccessToken);

        if (principal?.Identity?.Name is null)
            return Unauthorized();

        var user = await userManager.FindByNameAsync(principal.Identity.Name);

        if (user is null || user.RefreshToken != model.RefreshToken || user.RefreshTokenExpiry < DateTime.UtcNow)
            return Unauthorized();

        var token = GenerateJwt(principal.Identity.Name);

        logger.LogInformation("Refresh succeeded");

        return Ok(new LoginResponse
        {
            JwtToken = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo,
            RefreshToken = model.RefreshToken
        });
    }

    [Authorize]
    [HttpDelete("Revoke")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Revoke()
    {
        logger.LogInformation("Revoke called");

        var username = HttpContext.User.Identity?.Name;

        if (username is null)
            return Unauthorized();

        var user = await userManager.FindByNameAsync(username);

        if (user is null)
            return Unauthorized();

        user.RefreshToken = null;

        await userManager.UpdateAsync(user);

        logger.LogInformation("Revoke succeeded");

        return Ok();
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        var secret = configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured");

        var validation = new TokenValidationParameters
        {
            ValidIssuer = configuration["JWT:ValidIssuer"],
            ValidAudience = configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
            ValidateLifetime = false
        };

        return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
    }

    private JwtSecurityToken GenerateJwt(string username)
    {
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured")));

        var token = new JwtSecurityToken(
            issuer: configuration["JWT:ValidIssuer"],
            audience: configuration["JWT:ValidAudience"],
            expires: DateTime.UtcNow.AddSeconds(30),
            claims: authClaims,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];

        using var generator = RandomNumberGenerator.Create();

        generator.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
}