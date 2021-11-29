using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace S10219526_StudentApp
{
    public static class Defaults
    {
        public static readonly CultureInfo Culture = new("en-SG");
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sampleDob = new DateTime(2000, 10, 3);
            var john = new Student(1, "John Tan", "88552211", sampleDob);
            var alex = new Student(2, "Alex Tan", "88552212", sampleDob);
            var farrell = new Student(3, "Farrell Tan", "88552213", sampleDob);
            var richard = new Student(4, "Richard Tan", "88552214", sampleDob);

            Console.WriteLine(Student.Header);
            // Console.WriteLine(john);
            // Console.WriteLine(alex);
            // Console.WriteLine(farrell);
            // Console.WriteLine(richard);

            var studentList = new List<Student> { john, alex, farrell, richard };
            DisplayOutput(studentList);

            studentList.Add(GetStudent());
            Console.WriteLine();

            var studentList2 = File.ReadAllLines(@".\Assets\Students.csv")
                .Skip(1)
                .ToList()
                .Select(l => new Student(l))
                .ToList();

            Console.WriteLine(Student.Header);
            DisplayOutput(studentList2);
        }

        public static void DisplayOutput(List<Student> sList)
        {
            sList.ForEach(Console.WriteLine);
        }

        public static Student GetStudent()
        {
            int id;
            while (true)
            {
                Console.Write("Enter the student ID: ");
                if (int.TryParse(Console.ReadLine(), out id)) break;
            }

            string name;
            while (true)
            {
                Console.Write("Enter the student name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name)) break;
            }

            string phone;
            while (true)
            {
                Console.Write("Enter the student's phone: ");
                phone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(phone)) break;
            }

            DateTime dob;
            while (true)
            {
                Console.Write("Enter the student date of birth: ");
                if (DateTime.TryParse(Console.ReadLine(), Defaults.Culture, DateTimeStyles.None, out dob)) break;
            }

            return new Student(id, name, phone, dob);
        }
    }
}