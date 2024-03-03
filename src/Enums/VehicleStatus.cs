using System.ComponentModel;

namespace SmartLocate.Admin.Enums;

public enum VehicleStatus
{
    [Description("Working")]
    Working,
    [Description("Under Maintenance")]
    UnderMaintenance,
    [Description("Accident")]
    Accident,
    [Description("Scrap")]
    Scrap,
    [Description("Stolen")]
    Stolen,
    [Description("Sold")]
    Sold,
    [Description("Other")]
    Other
}