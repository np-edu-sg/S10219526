namespace AssignmentFinal.Models;

public class Booking
{
    public int BookingId { get; set; }
    public int NoOfAdultTicket { get; set; }
    public int NoOfChildTicket { get; set; }
    public double? AdultSalesPrice { get; set; }
    public double? ChildSalesPrice { get; set; }
    public DateTime BookDateTime { get; set; }
    public string BookStatus { get; set; } = null!;
    public int PgrId { get; set; }
    public int EventSessionEventId { get; set; }
    public int EventSessionSessionNo { get; set; }

    public virtual EventSession EventSession { get; set; } = null!;
    public virtual Passenger Pgr { get; set; } = null!;
}