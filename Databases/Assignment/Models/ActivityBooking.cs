using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class ActivityBooking
    {
        public int Id { get; set; }
        [Required] public ActivitySlot ActivitySlot { get; set; }
    }
}