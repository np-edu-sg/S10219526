using System;

namespace Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            while (true)
            {
                Console.Write("Enter a number: ");
                if (int.TryParse(Console.ReadLine(), out number)) break;
            }

            for (var idx = 1; idx <= 12; idx++)
            {
                Console.WriteLine($"{idx}\t{idx * number}");
            }
        }
    }
}