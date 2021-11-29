using System;
using System.Collections.Generic;
using System.IO;

namespace BookingApp_S10219526
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookings = new List<Booking>();
            var lines = File.ReadAllLines("./Assets/booking.csv");

            foreach (var line in lines[1..])
            {
                var split = line.Split(",");
                var d = double.Parse(split[1]);
                var m = bool.Parse(split[3]);
                bookings.Add(new Booking(split[0], d, split[2], m));
            }

            Console.WriteLine($"{"ID",-20}{"Duration(min)",-20}{"Status",-20}{"Membership",-20}{"Charges($)",20}");
            foreach (var b in bookings)
            {
                Console.WriteLine(b);
            }

            Console.Write("Enter booking ID: ");
            var bookingInput = Console.ReadLine();

            var bookingIdx = -1;
            for (var idx = 0; idx < bookings.Count; idx++)
            {
                if (bookings[idx].Id != bookingInput) continue;
                
                bookingIdx = idx;
                break;
            }

            if (bookingIdx == -1)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            var booking = bookings[bookingIdx];
            
            Console.WriteLine("Booking found.");
            Console.WriteLine(
                $"Details ID: {booking.Id,-10}Duration: {booking.Duration,-10}Status: {booking.Status,-18}Membership: {booking.Membership}");
            
            double duration;
            while (true)
            {
                Console.Write("Enter updated duration: ");
                if (double.TryParse(Console.ReadLine(), out duration)) break;
                Console.WriteLine("Please enter a valid duration.");
            }

            bookings[bookingIdx].Duration = duration;

            Console.WriteLine($"{"ID",-20}{"Duration(min)",-20}{"Status",-20}{"Membership",-20}{"Charges($)",20}");
            foreach (var b in bookings)
            {
                Console.WriteLine(b);
            }
        }
    }
}