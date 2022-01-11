using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class CategorisedIn
{
    [Column("DishID")] public int DishId { get; set; }
    [Column("FoodCategoryID")] public int FoodCategoryId { get; set; }
}