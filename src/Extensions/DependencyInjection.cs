using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using SmartLocate.Admin.Services;
using SmartLocate.Admin.Services.HttpClients;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace SmartLocate.Admin.Extensions;

internal static class DependencyInjection
{
    internal static IServiceCollection RegisterServices(this IServiceCollection services, string backendUrl)
    {
        services.AddAuthorizationCore(options => options.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());
        services.AddHttpClient("SmartLocateAPI", client => client.BaseAddress = new Uri(backendUrl)).AddHttpMessageHandler<AuthorizationHeaderHandler>();
        services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("SmartLocateAPI").EnableIntercept(sp));
        services.AddTransient<AuthenticationStateProvider, ApplicationAuthStateProvider>();
        services.AddTransient<ApplicationAuthStateProvider>();
        services.AddBlazoredLocalStorage();
        services.AddMudServices();
        services.AddSingleton<AppThemeService>();
        services.AddTransient<AuthorizationHeaderHandler>();
        services.AddHttpClientInterceptor();
        services.RegisterHttpClients();
        return services;
    }

    private static void RegisterHttpClients(this IServiceCollection services)
    {
        services.AddTransient<AdminUserHttpClient>();
        services.AddTransient<BusHttpClient>();
        services.AddTransient<BusDriverHttpClient>();
        services.AddTransient<BusRouteHttpClient>();
        services.AddTransient<SearchHttpClient>();
        services.AddTransient<StudentHttpClient>();
    }
}