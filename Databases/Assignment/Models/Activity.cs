using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Assignment.Models
{
    [Table("Activity")]
    public class Activity
    {
        public int Id { get; set; }
        public int DurationSeconds { get; set; }
        [Required] public string Description { get; set; }

        public List<ActivitySlot> ActivitySlots { get; set; }
    }
}