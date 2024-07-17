using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace iTrendz.MauiUI;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public async Task Login(string token)
    {
        await SecureStorage.SetAsync("accounttoken", token);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task Logout()
    {
        SecureStorage.Remove("accounttoken");
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var userInfo = await SecureStorage.GetAsync("accounttoken");
            if (userInfo != null)
            {
                var claims = new[] { new Claim(ClaimTypes.Name, "Sample User") };
                var identity = new ClaimsIdentity(claims, "Custom authentication");
                return new AuthenticationState(new ClaimsPrincipal(identity));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Request failed:" + ex.ToString());
        }

        return new AuthenticationState(new ClaimsPrincipal());
    }
}