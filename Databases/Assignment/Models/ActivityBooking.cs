using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public class ActivityBooking
    {
        public Guid Id { get; set; }
        public ActivitySlot ActivitySlot { get; set; }
    }
}