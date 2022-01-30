namespace AssignmentFinal.Models;

public class Order
{
    public DateTime OrderDateTime { get; set; }
    public int PgrId { get; set; }
    public int DishId { get; set; }
    public int OrderQty { get; set; }
    public double OrderPrice { get; set; }
    public string DeliverTo { get; set; } = null!;
    public DateTime DelDateTime { get; set; }

    public virtual Dish Dish { get; set; } = null!;
    public virtual Passenger Pgr { get; set; } = null!;
}