using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Table
    {
        public int No { get; set; }
        [Required] public int DiningLocationId { get; set; }
        [Required] public DiningLocation DiningLocation { get; set; }
        public Reservation Reservation { get; set; }
    }
}