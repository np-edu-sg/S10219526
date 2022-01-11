using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class FoodCategory
{
    [Column("FcID")] public int Id { get; set; }
    [Column("FcName")] public string Name { get; set; }
    [Column("FcDescr")] public string Description { get; set; }
    
    public ICollection<CategorisedIn> CategorisedIn { get; set; }
}