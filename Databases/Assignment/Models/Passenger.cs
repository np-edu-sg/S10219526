using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public List<ClassBooking> ClassBookings { get; set; }
        public List<ActivityBooking> ActivityBookings { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}