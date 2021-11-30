using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Assignment.Models
{
    public class Activity
    {
        public int Id { get; set; }
        [Required] public string Venue { get; set; }
        [Required] public string Description { get; set; }

        public List<ActivitySlot> ActivitySlots { get; set; }
    }
}