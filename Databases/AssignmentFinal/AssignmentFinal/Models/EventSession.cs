namespace AssignmentFinal.Models;

public class EventSession
{
    public EventSession()
    {
        Bookings = new HashSet<Booking>();
    }

    public int SessionNo { get; set; }
    public int EventId { get; set; }
    public DateTime EventDateTime { get; set; }

    public virtual Event Event { get; set; } = null!;
    public virtual ICollection<Booking> Bookings { get; set; }
}