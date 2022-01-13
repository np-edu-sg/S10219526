using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class Dish
{
    [Column("DishID")] public int Id { get; set; }
    [Column("DishName")] public string Name { get; set; }
    [Column("DishDescr")] public string Description { get; set; }

    [Column("CuisineID")] public int CuisineId { get; set; }

    [Column("EatyID")] public int? EateryId { get; set; }

    public CsDish CsDish { get; set; }
    public List<Order> Orders { get; set; }
    public ICollection<CategorisedIn> CategorisedIn { get; set; }
    public ICollection<Contain> Contains { get; set; }
}