using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    [Table("ClassBooking")]
    public class ClassBooking
    {
        public int Id { get; set; }

        [Required] public Passenger Passenger { get; set; }
        [Required] public Class Class { get; set; }
    }
}