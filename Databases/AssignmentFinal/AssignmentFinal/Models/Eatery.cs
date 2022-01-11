using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AssignmentFinal.Models;

public class Eatery
{
    [Column("EatyID")] public int Id { get; set; }
    [Column("EatyName")] public string Name { get; set; }
    [Column("EatyClHr")] public TimeOnly ClosingHours { get; set; }
    [Column("EatyOpHr")] public TimeOnly OpeningHours { get; set; }
    [Column("EatyCapacity")] public Int32 Capcacity { get; set; }
    [Column("EatyLoc")] public string Location { get; set; }
    
    public List<Reservation> Reservations { get; set; }
}