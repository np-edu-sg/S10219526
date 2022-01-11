using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class EventSession
{
    public int SessionNo { get; set; }
    public DateTime EventDateTime { get; set; }

    [Column("EventID")] public int EventId { get; set; }
    public List<Booking> Bookings { get; set; }
}