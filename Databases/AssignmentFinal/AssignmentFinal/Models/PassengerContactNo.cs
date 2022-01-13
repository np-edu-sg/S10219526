using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class PassengerContactNo
{
    [Column("PgrID")] public int PassengerId { get; set; }
    public string ContactNo { get; set; }
}