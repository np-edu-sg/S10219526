using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFinal.Models;

public class EventType
{
    [Column("ETID")] public int Id { get; set; }
    [Column("ETName")] public string Name { get; set; }
    
    public List<Event> Events { get; set; }
}