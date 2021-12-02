using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    [Table("ActivityBooking")]
    public class ActivityBooking
    {
        public int Id { get; set; }
        [Required] public ActivitySlot ActivitySlot { get; set; }
    }
}