using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SmartLocate.Admin;
using SmartLocate.Admin.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var backendUrl = builder.Configuration["BACKEND_API"] ?? "https://api.smartlocate.maverick-apps.com";

builder.Services.RegisterServices(backendUrl);

await builder.Build().RunAsync();
