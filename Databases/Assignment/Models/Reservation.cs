using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        
        public Passenger Passenger { get; set; }
        public List<Table> Tables { get; set; }
    }
}