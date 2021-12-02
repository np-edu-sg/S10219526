using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    public enum DishOrderStatus
    {
        Queued,
        InProgress,
        Completed
    }

    [Table("DishOrder")]
    public class DishOrder
    {
        public int Id { get; set; }
        [Required] public DishOrderStatus Status { get; set; }

        [Required] public Dish Dish { get; set; }
        [Required] public CabinService CabinService { get; set; }
    }
}