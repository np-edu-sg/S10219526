using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Dish
    {
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAlcoholic { get; set; }
        public bool IsVegan { get; set; }
        public bool IsHalal { get; set; }
        public string Allergens { get; set; }

        [Required] public int DiningLocationId { get; set; }
        [Required] public DiningLocation DiningLocation { get; set; }
        public List<DishOrder> DishOrders { get; set; }
    }
}