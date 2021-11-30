using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class ActivitySlot
    {
        public int Id { get; set; }
        [Required] public DateTime DateTime { get; set; }

        [Required] public Activity Activity { get; set; }
        public List<ActivityBooking> ActivityBookings { get; set; }
    }
}