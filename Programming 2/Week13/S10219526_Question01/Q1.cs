using System;

namespace S10219526_Question01
{
    class Q1
    {
        public static void Run()
        {
            double weight;
            while (true)
            {
                Console.Write("Enter your weight (kg): ");
                if (double.TryParse(Console.ReadLine(), out weight)) break;
            }

            double height;
            while (true)
            {
                Console.Write("Enter your height (m): ");
                if (double.TryParse(Console.ReadLine(), out height)) break;
            }

            var bmi = weight / (height * height);
            Console.WriteLine($"Your body mass index is {bmi}");
            switch (bmi)
            {
                case < 18.5:
                    Console.WriteLine("You are Under weight.");
                    break;
                case < 23:
                    Console.WriteLine("You are Normal weight.");
                    break;
                case < 27.5:
                    Console.WriteLine("You are Over weight.");
                    break;
                default:
                    Console.WriteLine("You are Obese.");
                    break;
            }
        }
    }
}