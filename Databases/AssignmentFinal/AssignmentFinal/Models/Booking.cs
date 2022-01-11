using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class Booking
{
    [Column("BookingID")] public int Id { get; set; }
    public int NoOfAdultTicket { get; set; }
    public int NoOfChildTicket { get; set; }
    public Int32 AdultSalesPrice { get; set; }
    public Int32 ChildSalesPrice { get; set; }
    [Column("BookDateTime")] public DateTime DateTime { get; set; }
    [Column("BookStatus")] public char Status { get; set; }

    [Column("PassengerID")] public int PassengerId { get; set; }
    [Column("EventSessionEventID")] public int EventSessionEventId { get; set; }
    [Column("EventSessionSessionNo")] public int EventSessionSessionNo { get; set; }
}