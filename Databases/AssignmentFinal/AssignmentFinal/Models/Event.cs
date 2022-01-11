using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class Event
{
    [Column("EventID")] public int EventId { get; set; }
    [Column("EventName")] public string Name { get; set; }
    [Column("EventDescr")] public string Description { get; set; }
    [Column("EventLoc")] public string Location { get; set; }
    [Column("EventCapacity")] public int Capacity { get; set; }
    [Column("EventDuration")] public int Duration { get; set; }
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public int AdultPrice { get; set; }
    public int ChildPrice { get; set; }

    public int EventTypeId { get; set; }
    public List<EventSession> EventSessions { get; set; }
}