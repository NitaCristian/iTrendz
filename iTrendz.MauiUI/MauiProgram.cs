﻿using iTrendz.Domain.Interfaces;
using iTrendz.MauiUI.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

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
        builder.Services.AddMudServices();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddScoped(_ => new HttpClient() { BaseAddress = new Uri("https://localhost:7061/api/") });
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>(sp =>
        {
            var httpClient = sp.GetRequiredService<HttpClient>();
            var logger = sp.GetRequiredService<ILogger<CustomAuthenticationStateProvider>>();
            return new CustomAuthenticationStateProvider(httpClient, logger);
        });
        builder.Services.AddScoped<ICampaignService, CampaignService>(sp =>
        {
            var httpClient = sp.GetRequiredService<HttpClient>();
            return new CampaignService(httpClient);
        });
        builder.Services.AddScoped<IBrandService, BrandService>(sp =>
        {
            var httpClient = sp.GetRequiredService<HttpClient>();
            return new BrandService(httpClient);
        });
        builder.Services.AddScoped<IContractService, ContractService>(sp =>
        {
            var httpClient = sp.GetRequiredService<HttpClient>();
            return new ContractService(httpClient);
        });
        builder.Services.AddScoped<IInfluencerService, InfluencerService>(sp =>
        {
            var httpClient = sp.GetRequiredService<HttpClient>();
            return new InfluencerService(httpClient);
        });

        return builder.Build();
    }
}