using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public class CabinService
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime ServeBy { get; set; }
        
        public List<DishOrder> DishOrders { get; set; }
    }
}