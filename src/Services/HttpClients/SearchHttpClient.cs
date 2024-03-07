using System.Net.Http.Json;
using SmartLocate.Admin.Models.Search;

namespace SmartLocate.Admin.Services.HttpClients;

public class SearchHttpClient(HttpClient httpClient)
{
    public Task<List<BusRouteSearchResponse>> SearchBusRoutes(string search, CancellationToken cancellationToken = default)
    {
        return httpClient.GetFromJsonAsync<List<BusRouteSearchResponse>>($"/search/bus-routes?query={search}", cancellationToken);
    }
}