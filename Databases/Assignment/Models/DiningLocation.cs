using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    [Table("DiningLocation")]
    public class DiningLocation
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        [Required] public DateTime TimeOpen { get; set; }
        [Required] public DateTime TimeClose { get; set; }

        public List<Dish> Dishes { get; set; }
        public List<Table> Tables { get; set; }
    }
}