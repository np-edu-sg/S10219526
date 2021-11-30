using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsVegan { get; set; }
        public bool IsHalal { get; set; }
        public string Allergens { get; set; }
        
        public DiningLocation DiningLocation { get; set; }
        public List<DishOrder> DishOrders { get; set; }
    }
}