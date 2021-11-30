using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class ClassBooking
    {
        public int Id { get; set; }

        [Required] public Passenger Passenger { get; set; }
        [Required] public Class Class { get; set; }
    }
}