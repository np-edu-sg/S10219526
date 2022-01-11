using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class Passenger
{
    [Column("PgrID")] public int Id { get; set; }
    [Column("PgrName")] public string Name { get; set; }
    [Column("PgrEmail")] public string Email { get; set; }
    [Column("PgrDOB")] public DateOnly DOB { get; set; }
    [Column("PgrGender")] public char Gender { get; set; }

    public List<Booking> Bookings { get; set; }
    public List<Reservation> Reservations { get; set; }
    public ICollection<Order> Orders { get; set; }
}