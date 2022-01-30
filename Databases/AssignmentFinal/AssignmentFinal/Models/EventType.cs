namespace AssignmentFinal.Models;

public class EventType
{
    public EventType()
    {
        Events = new HashSet<Event>();
    }

    public int Etid { get; set; }
    public string Etname { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; }
}