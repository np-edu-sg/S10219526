using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Venue { get; set; }
        public string Description { get; set; }
        
        public List<ActivitySlot> ActivitySlots { get; set; }
    }
}