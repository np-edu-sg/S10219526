using System;

namespace Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("------------- MENU --------------");
                Console.WriteLine("[1] Calculate Body Mass Index");
                Console.WriteLine("[2] Calculate Discount");
                Console.WriteLine("[3] Display Multiplication Table");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("---------------------------------");
                int option;
                while (true)
                {
                    Console.Write("Enter your option: ");
                    if (int.TryParse(Console.ReadLine(), out option) && option is >= 0 and <= 3) break;
                    Console.WriteLine("Invalid option! Please try again.");
                }

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Bye");
                        return;
                    case 1:
                        Console.WriteLine("BMI Calculation");
                        Q1.Run();
                        break;
                    case 2:
                        Console.WriteLine("Discount Calculation");
                        Q2.Run();
                        break;
                    case 3:
                        Console.WriteLine("Multiplication Calculation");
                        Q3.Run();
                        break;
                }
            }
        }
    }
}