using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class CsDish
{
    [Column("DishID")] public int DishId { get; set; }
    public double Price { get; set; }
    
    public ICollection<Order> Orders { get; set; }
}