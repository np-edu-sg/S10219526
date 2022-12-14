using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    [Table("ActivitySlot")]
    public class ActivitySlot
    {
        [Required] public string Venue { get; set; }
        [Required] public DateTime DateTime { get; set; }
        [Required] public int Capacity { get; set; }
        
        [Required] public int ActivityId { get; set; }
        [Required] public Activity Activity { get; set; }
        public List<ActivityBooking> ActivityBookings { get; set; }
    }
}