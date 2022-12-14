using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    [Table("CabinService")]
    public class CabinService
    {
        public int Id { get; set; }
        [Required] public DateTime OrderDateTime { get; set; }
        [Required] public DateTime ServeBy { get; set; }

        public List<DishOrder> DishOrders { get; set; }
    }
}