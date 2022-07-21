using BlazorApp1;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RazorClassLibrary1;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

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

await builder.Build().RunAsync();
