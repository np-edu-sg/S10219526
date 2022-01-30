namespace AssignmentFinal.Models;

public class Cuisine
{
    public Cuisine()
    {
        Dishes = new HashSet<Dish>();
    }

    public int CuisineId { get; set; }
    public string CuisineName { get; set; } = null!;

    public virtual ICollection<Dish> Dishes { get; set; }
}