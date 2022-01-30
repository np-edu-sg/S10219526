namespace AssignmentFinal.Models;

public class FoodCategory
{
    public FoodCategory()
    {
        Dishes = new HashSet<Dish>();
    }

    public int FcId { get; set; }
    public string FcName { get; set; } = null!;
    public string FcDescr { get; set; } = null!;

    public virtual ICollection<Dish> Dishes { get; set; }
}