using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.Extensions.Configuration;
using RazorClassLibrary1;
using System.Reflection;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services
                .AddBlazorise(options =>
                {
                    options.Immediate = true;
                })
                .AddBootstrap5Providers()
                .AddFontAwesomeIcons();

            builder.Services.AddMauiBlazorWebView();

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("MauiApp1.wwwroot.appsettings.json");

            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder.Configuration.AddConfiguration(config);
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddScoped(client => new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration["STARWARS_API_ENDPOINT"] ?? string.Empty)
            });

            builder.Services.AddHttpClient("NamedHttpClient", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["STARWARS_API_ENDPOINT"] ?? string.Empty);
            });

            builder.Services.AddHttpClient<TypedHttpClientPersonService>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["STARWARS_API_ENDPOINT"] ?? string.Empty);
            });

            builder.Services.AddScoped<WeatherForecastService>();
            builder.Services.AddScoped<ExampleJsInterop>();
            builder.Services.AddScoped<HttpClientPersonService>();
            builder.Services.AddScoped<NamedHttpClientPersonService>();
            builder.Services.AddScoped<InheritedNamedHttpClientPersonService>();

            return builder.Build();
        }
    }
}