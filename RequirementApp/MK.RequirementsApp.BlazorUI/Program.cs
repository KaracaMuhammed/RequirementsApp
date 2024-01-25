using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MK.RequirementsApp.BlazorUI;
using MK.RequirementsApp.BlazorUI.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.RegisterServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var host = builder.Build();

var uriHelper = host.Services.GetRequiredService<NavigationManager>();
uriHelper.NavigateTo("requirements", forceLoad: false);

await host.RunAsync();
