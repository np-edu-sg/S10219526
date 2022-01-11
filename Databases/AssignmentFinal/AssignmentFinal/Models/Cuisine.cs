using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class Cuisine
{
    [Column("CuisineID")] public int Id { get; set; }
    public string CuisineName { get; set; }
    
    public List<Dish> Dishes { get; set; }
}