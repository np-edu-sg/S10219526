namespace AssignmentFinal.Models;

public class Ingredient
{
    public Ingredient()
    {
        Dishes = new HashSet<Dish>();
    }

    public int IngredId { get; set; }
    public string IngredName { get; set; } = null!;

    public virtual ICollection<Dish> Dishes { get; set; }
}