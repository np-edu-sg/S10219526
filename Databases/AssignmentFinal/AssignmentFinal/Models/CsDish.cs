namespace AssignmentFinal.Models;

public class CsDish
{
    public int DishId { get; set; }
    public double Price { get; set; }

    public virtual Dish Dish { get; set; } = null!;
}