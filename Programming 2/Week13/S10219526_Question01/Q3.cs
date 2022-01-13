using System;

namespace S10219526_Question01
{
    class Q3
    {
        public static void Run()
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