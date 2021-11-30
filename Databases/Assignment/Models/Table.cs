using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Table
    {
        public int Id { get; set; }
        [Required] public DiningLocation DiningLocation { get; set; }
        public Reservation Reservation { get; set; }
    }
}