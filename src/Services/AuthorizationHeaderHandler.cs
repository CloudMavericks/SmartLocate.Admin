using System.Net.Http.Headers;
using Blazored.LocalStorage;
using SmartLocate.Admin.Constants;

namespace SmartLocate.Admin.Services;

public class AuthorizationHeaderHandler(ILocalStorageService localStorageService) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.Headers.Authorization?.Scheme != "Bearer")
        {
            var savedToken = await localStorageService.GetItemAsync<string>(StorageConstants.AuthToken, cancellationToken);
            if (!string.IsNullOrWhiteSpace(savedToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
            }
        }
        return await base.SendAsync(request, cancellationToken);
    }
}