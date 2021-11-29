using System;
using System.Collections.Generic;
using System.Linq;

namespace S10219526_EmployeeApp
{
    class SalesEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BasicSalary { get; set; }
        public double Sales { get; set; }
        public static string Header => $"{"Id",-5}{"Name",-10}{"Basic Salary",-15}{"Sales",-10}";

        public SalesEmployee(int id, string name, double basicSalary, double sales)
        {
            Id = id;
            Name = name;
            BasicSalary = basicSalary;
            Sales = sales;
        }

        public override string ToString()
        {
            return $"{Id,-5}{Name,-10}{BasicSalary,-15}{Sales,-10}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var one = new SalesEmployee(101, "Angie", 1200, 15000);
            var two = new SalesEmployee(105, "Cindy", 1000, 12000);
            var three = new SalesEmployee(108, "David", 1500, 20000);
            var four = new SalesEmployee(112, "Jason", 3000, 30000);
            var five = new SalesEmployee(127, "Vivian", 2000, 25000);

            var employeeList = new List<SalesEmployee> { one, two, three, four, five };
            Console.WriteLine(SalesEmployee.Header);
            employeeList.ForEach(Console.WriteLine);

            Console.Write("Enter a name: ");
            var name = Console.ReadLine();
            var e = employeeList.SingleOrDefault(e => e.Name == name);
            if (e == default(SalesEmployee)) Console.WriteLine("Employee not found!");
            else
            {
                Console.WriteLine();
                Console.WriteLine(SalesEmployee.Header);
                Console.WriteLine(e);
            }
        }
    }
}