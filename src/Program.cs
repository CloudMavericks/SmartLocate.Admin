using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SmartLocate.Admin;
using SmartLocate.Admin.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var backendUrl = builder.Configuration["BACKEND_API"];

if(string.IsNullOrWhiteSpace(backendUrl))
{
    throw new Exception("Unable to parse Backend URL from Environment. Please configure it properly.");
}

builder.Services.RegisterServices(backendUrl);

await builder.Build().RunAsync();
