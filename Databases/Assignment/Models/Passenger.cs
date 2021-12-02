using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    [Table("Passenger")]
    public class Passenger
    {
        public int Id { get; set; }
        public int CabinNo { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<ClassBooking> ClassBookings { get; set; }
        public List<ActivityBooking> ActivityBookings { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}