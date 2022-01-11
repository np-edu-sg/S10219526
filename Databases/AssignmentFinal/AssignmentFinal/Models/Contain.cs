using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class Contain
{
    [Column("DishID")] public int DishId { get; set; }
    [Column("IngredientID")] public int IngredientId { get; set; }
}