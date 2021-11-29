using System;
using System.Runtime.CompilerServices;

namespace Q4
{
    class Q2
    {
        public static void Run()
        {
            double amount;
            while (true)
            {
                Console.Write("Enter amount ($): ");
                if (double.TryParse(Console.ReadLine(), out amount)) break;
            }

            var discount = GetDiscount(amount);
            Console.WriteLine($"Discount given (%): {discount}");
            Console.WriteLine($"Discount amount ($): {(amount * (discount / 100.0)):N2}");
        }

        private static int GetDiscount(double amount)
        {
            return amount switch
            {
                < 100 => 0,
                <=500 => 5,
                <=1000 => 10,
                _ => 20
            };
        }
    }
}