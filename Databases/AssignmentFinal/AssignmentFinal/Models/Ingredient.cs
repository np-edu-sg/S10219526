using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class Ingredient
{
    [Column("IngredID")] public int Id { get; set; }
    [Column("IngredName")] public string Name { get; set; }
    
    public ICollection<Contain> Contains { get; set; }
}