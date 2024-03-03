using System.ComponentModel.DataAnnotations;
using SmartLocate.Admin.Enums;

namespace SmartLocate.Admin.Models.Buses;

public class CreateBusRequest
{
    [Required(ErrorMessage = "Vehicle number is required", AllowEmptyStrings = false)]
    public string VehicleNumber { get; set; }

    [Required(ErrorMessage = "Vehicle model is required", AllowEmptyStrings = false)]
    public string VehicleModel { get; set; }

    [Required(ErrorMessage = "Vehicle status is required", AllowEmptyStrings = false)]
    public VehicleStatus Status { get; set; }
}