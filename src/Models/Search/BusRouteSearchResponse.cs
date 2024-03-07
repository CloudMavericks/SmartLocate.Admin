namespace SmartLocate.Admin.Models.Search;

public record BusRouteSearchResponse(Guid Id, int RouteNumber, string RouteName) 
{
    public override string ToString()
    {
        return $"{RouteNumber} - {RouteName}";
    }
}