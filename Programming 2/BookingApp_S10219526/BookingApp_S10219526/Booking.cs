using System;

namespace BookingApp_S10219526
{
    public class Booking
    {
        public string Id { get; set; }
        public double Duration { get; set; }
        public string Status { get; set; }
        public bool Membership { get; set; }

        public Booking(string id, double duration, string status, bool membership)
        {
            Id = id;
            Duration = duration;
            Status = status;
            Membership = membership;
        }

        public double CalculateCharges()
        {
            if (Duration <= 60)
            {
                return Membership ? 0 : 7;
            }

            return 3 * Math.Ceiling((Duration - 60) / 30) + (Membership ? 0 : 7);
        }

        public override string ToString()
        {
            return $"{Id,-20}{Duration,-20}{Status,-20}{Membership,-20}{CalculateCharges(),20:N2}";
        }
    }
}