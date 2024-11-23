using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using MudBlazor.Services;
using OneClick.WASM;
using OneClick.WASM.Identity;
using OneClick.WASM.Repositories.AppUsers;
using OneClick.WASM.UseCases;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// register the cookie handler
builder.Services.AddTransient<CookieHandler>();

// set up authorization
builder.Services.AddAuthorizationCore();

// register the custom state provider
builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();

// register the account management interface
builder.Services.AddScoped(
    sp => (IAccountManagement)sp.GetRequiredService<AuthenticationStateProvider>());

// set base address for default host
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "https://localhost:5002") });

// configure client for auth interactions
builder.Services.AddHttpClient(
    "Auth",
    //opt => opt.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:5001"))
    opt => opt.BaseAddress = new Uri("https://localhost:7186"))
    //opt => opt.BaseAddress = new Uri("http://178.69.23.201:5000"))
    //opt => opt.BaseAddress = new Uri("http://localhost:5050"))
    .AddHttpMessageHandler<CookieHandler>();

builder.Services.AddMudServices();
builder.Services.AddScoped<IUserWasmRepository, UserWasmRepository>();

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});



//----------------------------------------

var host = builder.Build();

const string defaultCulture = "ru-RU";


var js = host.Services.GetRequiredService<IJSRuntime>();
var result = await js.InvokeAsync<string>("blazorCulture.get");
var culture = CultureInfo.GetCultureInfo(result ?? defaultCulture);

if (result == null)
{
    await js.InvokeVoidAsync("blazorCulture.set", defaultCulture);
}

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();