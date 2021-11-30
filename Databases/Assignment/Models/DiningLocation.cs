using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public class DiningLocation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        
        public List<Dish> Dishes { get; set; }
        public List<Table> Tables { get; set; }
    }
}