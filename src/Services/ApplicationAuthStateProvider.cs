using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SmartLocate.Admin.Constants;

namespace SmartLocate.Admin.Services;

public class ApplicationAuthStateProvider(HttpClient httpClient, ILocalStorageService localStorageService)
    : AuthenticationStateProvider
{
    public ClaimsPrincipal AuthenticationStateUser { get; set; }

    public async Task UpdateAuthenticationStateAsync()
    {
        var savedToken = await localStorageService.GetItemAsync<string>(StorageConstants.AuthToken);
        if (string.IsNullOrWhiteSpace(savedToken))
        {
            var anonymousState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(null, null,
                SmartLocateClaimTypes.AdminName, SmartLocateClaimTypes.Type)));
            NotifyAuthenticationStateChanged(Task.FromResult(anonymousState));
        }
        else
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
            var authenticatedState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(
                [.. GetClaimsFromJwt(savedToken)], "jwt", SmartLocateClaimTypes.AdminName,
                SmartLocateClaimTypes.Type)));
            NotifyAuthenticationStateChanged(Task.FromResult(authenticatedState));
        }
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var savedToken = await localStorageService.GetItemAsync<string>(StorageConstants.AuthToken);
        if (string.IsNullOrWhiteSpace(savedToken))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(null, null,
                SmartLocateClaimTypes.AdminName, SmartLocateClaimTypes.Type)));
        }
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
        var state = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(
            [.. GetClaimsFromJwt(savedToken)], "jwt", SmartLocateClaimTypes.AdminName,
            SmartLocateClaimTypes.Type)));
        AuthenticationStateUser = state.User;
        return state;
    }

    private static List<Claim> GetClaimsFromJwt(string jwt)
    {
        var claims = new List<Claim>();
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        if (keyValuePairs == null)
            return claims;

        claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value?.ToString() ?? "")));
        return claims;
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}