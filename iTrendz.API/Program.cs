using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using iTrendz.Api.Authentication;
using iTrendz.Api.DataAccess.Context;
using iTrendz.Api.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TrendzDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<TrendzUser, IdentityRole<int>>(options =>
        options.User.AllowedUserNameCharacters += " ")
    .AddEntityFrameworkStores<TrendzDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<ICampaignRepository, SqliteCampaignRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter 'Bearer [jwt]'",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    options.AddSecurityRequirement(new OpenApiSecurityRequirement { { scheme, Array.Empty<string>() } });
});

using var loggerFactory = LoggerFactory.Create(b => b.SetMinimumLevel(LogLevel.Trace).AddConsole());

var secret = builder.Configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured");

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
            ClockSkew = new TimeSpan(0, 0, 5)
        };
        options.Events = new JwtBearerEvents
        {
            OnChallenge = ctx => LogAttempt(ctx.Request.Headers, "OnChallenge"),
            OnTokenValidated = ctx => LogAttempt(ctx.Request.Headers, "OnTokenValidated")
        };
    });

const string policy = "defaultPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(policy,
        p =>
        {
            p.AllowAnyHeader();
            p.AllowAnyMethod();
            p.AllowAnyHeader();
            p.AllowAnyOrigin();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

Task LogAttempt(IHeaderDictionary headers, string eventType)
{
    var logger = loggerFactory.CreateLogger<Program>();

    var authorizationHeader = headers["Authorization"].FirstOrDefault();

    if (authorizationHeader is null)
        logger.LogInformation($"{eventType}. JWT not present");
    else
    {
        string jwtString = authorizationHeader.Substring("Bearer ".Length);

        var jwt = new JwtSecurityToken(jwtString);

        logger.LogInformation(
            $"{eventType}. Expiration: {jwt.ValidTo.ToLongTimeString()}. System time: {DateTime.UtcNow.ToLongTimeString()}");
    }

    return Task.CompletedTask;
}