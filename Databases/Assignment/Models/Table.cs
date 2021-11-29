using System;

namespace Assignment.Models
{
    public class Table
    {
        public Guid Id { get; set; }
        public DiningLocation DiningLocation { get; set; }

        public Reservation Reservation { get; set; }
    }
}