using System;

namespace Assignment.Models
{
    public class DishOrder
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        
        public Dish Dish { get; set; }
        public CabinService CabinService { get; set; }
    }
}