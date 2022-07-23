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

builder.Services.AddMsalAuthentication(options =>
{
    options.ProviderOptions.LoginMode = "Redirect";

    options.ProviderOptions.Authentication.Authority = builder.Configuration.GetValue<string>("AUTH_AUTHORITY");
    options.ProviderOptions.Authentication.ClientId = builder.Configuration.GetValue<string>("AUTH_CLIENT_ID");
    options.ProviderOptions.Authentication.ValidateAuthority = builder.Configuration.GetValue<bool>("AUTH_VALIDATE_AUTHORITY");

    // If a scope is NOT provided the user will not be able to login as no access token will be returned
    // See https://docs.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/standalone-with-azure-active-directory?view=aspnetcore-3.1#access-token-scopes for more information

    foreach (var scope in (builder.Configuration["AUTH_SCOPES"] ?? string.Empty).Split(","))
    {
        options.ProviderOptions.DefaultAccessTokenScopes.Add(scope);
    }
});

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

await builder.Build().RunAsync();
