using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public class ClassBooking
    {
        public int Id { get; set; }
        
        public Passenger Passenger { get; set; }
        public Class Class { get; set; }
    }
}