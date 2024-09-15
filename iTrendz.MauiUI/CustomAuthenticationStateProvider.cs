﻿using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using iTrendz.Domain.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace iTrendz.MauiUI;

public class CustomAuthenticationStateProvider(HttpClient httpClient, ILogger<CustomAuthenticationStateProvider> logger)
    : AuthenticationStateProvider
{
    private const string TokenKey = "authToken";
    private const string RefreshTokenKey = "refreshToken";
    private const string ExpirationKey = "tokenExpiration";
    private AuthenticationState AnonymousUser { get; } = new(new ClaimsPrincipal(new ClaimsIdentity()));

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var token = await SecureStorage.GetAsync(TokenKey);
            var expiration = await SecureStorage.GetAsync(ExpirationKey);
            var refreshToken = await SecureStorage.GetAsync(RefreshTokenKey);

            if (!string.IsNullOrEmpty(token) && DateTime.TryParse(expiration, out var exp) && exp > DateTime.UtcNow)
                return CreateAuthenticationState(token);

            if (string.IsNullOrEmpty(refreshToken))
                return AnonymousUser;

            var newToken = await RefreshToken(refreshToken);
            return string.IsNullOrEmpty(newToken) ? AnonymousUser : CreateAuthenticationState(newToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting authentication state.");
            return AnonymousUser;
        }
    }

    public async Task Login(string token, DateTime expiration, string refreshToken)
    {
        try
        {
            await SecureStorage.SetAsync(TokenKey, token);
            await SecureStorage.SetAsync(ExpirationKey, expiration.ToString("O"));
            await SecureStorage.SetAsync(RefreshTokenKey, refreshToken);

            NotifyAuthenticationStateChanged(Task.FromResult(CreateAuthenticationState(token)));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error during login.");
        }
    }

    public void Logout()
    {
        try
        {
            SecureStorage.Remove(TokenKey);
            SecureStorage.Remove(ExpirationKey);
            SecureStorage.Remove(RefreshTokenKey);

            NotifyAuthenticationStateChanged(Task.FromResult(AnonymousUser));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error during logout.");
        }
    }

    private async Task<string?> RefreshToken(string refreshToken)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("https://localhost:7061/api/Authentication/Refresh",
                new { RefreshToken = refreshToken });
            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<LoginResponseDto>();

            if (result is null)
                return null;

            await SecureStorage.SetAsync(TokenKey, result.JwtToken);
            await SecureStorage.SetAsync(ExpirationKey, result.Expiration.ToString("O"));
            await SecureStorage.SetAsync(RefreshTokenKey, result.RefreshToken);

            return result.JwtToken;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error refreshing token.");
            return null;
        }
    }

    private AuthenticationState CreateAuthenticationState(string token)
    {
        return new AuthenticationState(new ClaimsPrincipal(GetClaimsIdentity(token)));
    }

    private ClaimsIdentity GetClaimsIdentity(string token)
    {
        var jwtHandler = new JwtSecurityTokenHandler();
        var jwtToken = jwtHandler.ReadJwtToken(token);
        return new ClaimsIdentity(jwtToken.Claims, "jwt");
    }
}