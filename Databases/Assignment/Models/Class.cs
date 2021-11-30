﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Class
    {
        public int Id { get; set; }
        [Required] public string Venue { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        [Required] public int IntervalMinutes { get; set; }

        public List<ClassBooking> ClassBookings { get; set; }
    }
}