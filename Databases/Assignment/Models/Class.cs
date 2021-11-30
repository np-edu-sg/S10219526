using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Venue { get; set; }
        public string Description { get; set; }
        public int IntervalSeconds { get; set; }
        
        public List<ClassBooking> ClassBookings { get; set; }
    }
}