using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class Reservation
{
    [Column("ReservID")] public int Id { get; set; }
    [Column("ReservStatus")] public string Status { get; set; }
    public DateTime RequiredDateTime { get; set; }
    public DateTime ReservationDateTime { get; set; }
    public Int16 NoOfPax { get; set; }

    [Column("EateryID")] public int EateryId { get; set; }
    [Column("PassengerID")] public int PassengerId { get; set; }
}