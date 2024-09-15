using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using iTrendz.Domain.DTOs;
using iTrendz.Domain.Models;

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
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDto requestDto)
    {
        var existingUser = await userManager.FindByNameAsync(requestDto.Username);
        if (existingUser != null)
            return Conflict("User already exists.");

        User newUser;
        switch (requestDto.UserType)
        {
            case "Brand":
                newUser = new Brand()
                {
                    UserName = requestDto.Username,
                    Email = requestDto.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Description = requestDto.Description
                };
                break;
            case "Influencer":
                newUser = new Influencer()
                {
                    UserName = requestDto.Username,
                    Email = requestDto.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Description = requestDto.Description
                };
                break;
            default:
                return BadRequest("Invalid user type specified.");
        }

        var result = await userManager.CreateAsync(newUser, requestDto.Password);

        if (!result.Succeeded)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Failed to create user: {string.Join(" ", result.Errors.Select(e => e.Description))}");
        }

        if (!await roleManager.RoleExistsAsync(requestDto.UserType))
        {
            await roleManager.CreateAsync(new IdentityRole<int>(requestDto.UserType));
        }

        await userManager.AddToRoleAsync(newUser, requestDto.UserType);

        return Ok("User successfully created");
    }

    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponseDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto)
    {
        logger.LogInformation("Login called");

        var user = await userManager.FindByNameAsync(requestDto.Username);

        if (user == null || !await userManager.CheckPasswordAsync(user, requestDto.Password))
            return Unauthorized();

        var token = GenerateJwt(requestDto.Username);

        var refreshToken = GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiry = DateTime.UtcNow.AddMinutes(1);

        await userManager.UpdateAsync(user);

        logger.LogInformation("Login succeeded");

        return Ok(new LoginResponseDto
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
    public async Task<IActionResult> Refresh([FromBody] RefreshRequestDto requestDto)
    {
        logger.LogInformation("Refresh called");

        var principal = GetPrincipalFromExpiredToken(requestDto.AccessToken);

        if (principal?.Identity?.Name is null)
            return Unauthorized();

        var user = await userManager.FindByNameAsync(principal.Identity.Name);

        if (user is null || user.RefreshToken != requestDto.RefreshToken || user.RefreshTokenExpiry < DateTime.UtcNow)
            return Unauthorized();

        var token = GenerateJwt(principal.Identity.Name);

        logger.LogInformation("Refresh succeeded");

        return Ok(new LoginResponseDto
        {
            JwtToken = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo,
            RefreshToken = requestDto.RefreshToken
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