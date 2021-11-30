using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class CabinService
    {
        public int Id { get; set; }
        [Required] public DateTime DateTime { get; set; }
        [Required] public DateTime ServeBy { get; set; }
        
        public List<DishOrder> DishOrders { get; set; }
    }
}