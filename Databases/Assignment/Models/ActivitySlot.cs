using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public class ActivitySlot
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public Activity Activity { get; set; }
        public List<ActivityBooking> ActivityBookings { get; set; }
    }
}