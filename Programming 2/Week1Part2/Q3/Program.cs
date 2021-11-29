using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Q3
{
    class Program
    {
        class Fare
        {
            public float UpTo { get; set; }
            public float Cents { get; set; }

            public Fare(string line)
            {
                var fields = line.Split(",");
                UpTo = float.Parse(fields[0]);
                Cents = float.Parse(fields[1]);
            }
        }

        class Stop
        {
            public float Distance { get; set; }
            public string Code { get; set; }
            public string Road { get; set; }
            public string Description { get; set; }

            public static string Header =>
                $"{"Distance",-10}{"Bus Stop Code",-15}{"Road",-20}{"Bus Stop Description",-20}";

            public Stop(string line)
            {
                var fields = line.Split(",");
                Distance = float.Parse(fields[0]);
                Code = fields[1];
                Road = fields[2];
                Description = fields[3];
            }

            public override string ToString()
            {
                return $"{Distance,-10}{Code,-15}{Road,-20}{Description,-20}";
            }
        }

        static async Task Main(string[] args)
        {
            var f = await File.ReadAllLinesAsync("./Assets/distance-based-fare.csv");
            var f2 = await File.ReadAllLinesAsync("./Assets/bus_174.csv");

            var fares = new List<Fare>();
            foreach (var line in f[1..])
            {
                fares.Add(new Fare(line));
            }

            var stops = new List<Stop>();
            foreach (var line in f2[1..])
            {
                var stop = new Stop(line);
                stops.Add(stop);
                Console.WriteLine(stop);
            }

            Console.WriteLine(Stop.Header);
            stops.ForEach(Console.WriteLine);

            Stop boarding;
            while (true)
            {
                Console.Write("Enter boarding bus stop: ");
                var i = Console.ReadLine();
                boarding = stops.SingleOrDefault(s => s.Code == i);
                if (boarding != default(Stop)) break;
                Console.WriteLine("Invalid bus stop!");
            }

            Stop alighting;
            while (true)
            {
                Console.Write("Enter alighting bus stop: ");
                var i = Console.ReadLine();
                alighting = stops.SingleOrDefault(s => s.Code == i);
                if (alighting != default(Stop)) break;
                Console.WriteLine("Invalid bus stop!");
            }

            var dist = Math.Abs(alighting.Distance - boarding.Distance);
            Console.WriteLine($"Distance travelled: {dist:N2}km");
            var fare = fares.Where(f3 => f3.UpTo >= dist).OrderBy(f3 => f3.UpTo).FirstOrDefault();
            if (fare == default(Fare)) throw new Exception("Cannot find fare");

            Console.WriteLine($"Fare to pay: {fare.Cents / 100:C2}");
            Console.WriteLine($"Estimated duration: {dist * 4:N0}mins");
        }
    }
}