using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class Order
{
    [Column("OrderQty")] public int Quantity { get; set; }
    [Column("OrderPrice")] public double Price { get; set; }
    [Column("OrderDateTime")] public DateTime DateTime { get; set; }
    public string DeliverTo { get; set; }
    public DateTime DelDateTime { get; set; }

    [Column("PgrID")] public int PassengerId { get; set; }
    [Column("DishID")] public int DishId { get; set; }
}