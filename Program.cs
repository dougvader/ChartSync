using ChartSync;
using ChartSync.Services;
using ChartSync.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// Single HttpClient registration
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register services
builder.Services.AddScoped<ChartService>();
builder.Services.AddScoped<GenreService>();
builder.Services.AddScoped<AuthService>();

var host = builder.Build();

try
{
    // 1. Load charts file
    var chartSvc = host.Services.GetRequiredService<ChartService>();
    await chartSvc.LoadChartsAsync();

    // 2. Build genres from those charts
    var genreSvc = host.Services.GetRequiredService<GenreService>();
    genreSvc.BuildGenres(chartSvc.AllCharts);
}
catch (Exception ex)
{
    Console.WriteLine($"[Startup Error] {ex.Message}\n{ex.StackTrace}");
}

await host.RunAsync();
