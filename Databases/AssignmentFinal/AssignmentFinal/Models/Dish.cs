namespace AssignmentFinal.Models;

public class Dish
{
    public Dish()
    {
        CsDishes = new HashSet<CsDish>();
        Orders = new HashSet<Order>();
        Fcs = new HashSet<FoodCategory>();
        Ingreds = new HashSet<Ingredient>();
    }

    public int DishId { get; set; }
    public string DishName { get; set; } = null!;
    public string DishDescr { get; set; } = null!;
    public int CuisineId { get; set; }
    public int? EatyId { get; set; }

    public virtual Cuisine Cuisine { get; set; } = null!;
    public virtual Eatery? Eaty { get; set; }
    public virtual ICollection<CsDish> CsDishes { get; set; }
    public virtual ICollection<Order> Orders { get; set; }

    public virtual ICollection<FoodCategory> Fcs { get; set; }
    public virtual ICollection<Ingredient> Ingreds { get; set; }
}