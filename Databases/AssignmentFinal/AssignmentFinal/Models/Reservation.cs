namespace AssignmentFinal.Models;

public class Reservation
{
    public int ReservId { get; set; }
    public string ReservStatus { get; set; } = null!;
    public DateTime RequiredDateTime { get; set; }
    public DateTime ReservationDateTime { get; set; }
    public short NoOfPax { get; set; }
    public int EatyId { get; set; }
    public int PgrId { get; set; }

    public virtual Eatery Eaty { get; set; } = null!;
    public virtual Passenger Pgr { get; set; } = null!;
}