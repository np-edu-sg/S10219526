using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Week1Part2
{
    class Phone
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public static string CsvHeader => "\"Name\",\"Number\"";

        public Phone(string name, string number)
        {
            Name = name;
            Number = number;
        }

        public override string ToString()
        {
            return $"\"{Name}\",\"{Number}\"";
        }
    }

    class Program
    {
        private static async Task Main(string[] args)
        {
            if (!File.Exists("./PhoneDirectory.csv"))
            {
                await File.AppendAllLinesAsync("./PhoneDirectory.csv", new[] { Phone.CsvHeader });
            }

            var counter = 0;
            while (true)
            {
                Console.Write("Enter new person name: ");
                var name = Console.ReadLine();
                if (name == "Exit") break;

                Console.Write("Enter new person phone number: ");
                var number = Console.ReadLine();
                var phone = new Phone(name, number);

                await File.AppendAllLinesAsync("./PhoneDirectory.csv", new[] { phone.ToString() });
                counter++;
            }

            Console.WriteLine($"Added {counter} record(s) to file.");
        }
    }
}