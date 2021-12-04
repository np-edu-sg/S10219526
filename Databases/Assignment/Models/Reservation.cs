using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        public int Id { get; set; }
        [Required] public DateTime StartDateTime { get; set; }
        [Required] public DateTime EndDateTime { get; set; }

        [Required] public Passenger Passenger { get; set; }

        [Required] public Table Table { get; set; }
        [Required] public int TableNo { get; set; }
        [Required] public int DiningLocationId { get; set; }
    }
}