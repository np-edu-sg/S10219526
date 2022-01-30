using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class Event
{
    public Event()
    {
        EventSessions = new HashSet<EventSession>();
    }

    public int EventId { get; set; }
    public string EventName { get; set; } = null!;
    public string EventDescr { get; set; } = null!;
    public string EventLoc { get; set; } = null!;
    public int EventCapacity { get; set; }
    public double EventDuration { get; set; }
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public double? AdultPrice { get; set; }
    public double? ChildPrice { get; set; }
    public int Etid { get; set; }

    public virtual EventType Et { get; set; } = null!;
    public virtual ICollection<EventSession> EventSessions { get; set; }
}