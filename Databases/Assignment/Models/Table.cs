using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    [Table("Table")]
    public class Table
    {
        public int No { get; set; }
        [Required] public int DiningLocationId { get; set; }
        [Required] public DiningLocation DiningLocation { get; set; }
        public Reservation Reservation { get; set; }
    }
}