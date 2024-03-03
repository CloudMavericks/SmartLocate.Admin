using System.Drawing;

namespace SmartLocate.Admin.Controls.Leaflet.Events;

public class ResizeEvent : Event
{
    public PointF OldSize { get; set; }
    public PointF NewSize { get; set; }
}