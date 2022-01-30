namespace AssignmentFinal.Models;

public class Passenger
{
    public Passenger()
    {
        Bookings = new HashSet<Booking>();
        Orders = new HashSet<Order>();
        PassengerContactNos = new HashSet<PassengerContactNo>();
        Reservations = new HashSet<Reservation>();
    }

    public int PgrId { get; set; }
    public string PgrName { get; set; } = null!;
    public string PgrEmail { get; set; } = null!;
    public DateTime PgrDob { get; set; }
    public string PgrGender { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<PassengerContactNo> PassengerContactNos { get; set; }
    public virtual ICollection<Reservation> Reservations { get; set; }
}