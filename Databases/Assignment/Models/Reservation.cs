using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required] public DateTime Time { get; set; }
        
        [Required] public Passenger Passenger { get; set; }
        [Required] public List<Table> Tables { get; set; }
    }
}