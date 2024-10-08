﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace iTrendz.MauiUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddScoped(_ => new HttpClient());
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>(sp =>
        {
            var httpClient = sp.GetRequiredService<HttpClient>();
            return new CustomAuthenticationStateProvider(httpClient);
        });

        return builder.Build();
    }
}