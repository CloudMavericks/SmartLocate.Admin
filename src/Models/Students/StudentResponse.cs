using SmartLocate.Admin.Controls.Leaflet;

namespace SmartLocate.Admin.Models.Students;

public record StudentResponse(
    Guid Id,
    string Name,
    string Email,
    string PhoneNumber,
    string Address,
    LatLng DefaultPickupDropOffLocation,
    Guid DefaultBusRouteId,
    int DefaultBusRouteNumber,
    bool IsActivated)
{
    public override string ToString()
    {
        return $"{Name}, BusRoute {DefaultBusRouteNumber}, <{Email}>, {PhoneNumber}";
    }
}