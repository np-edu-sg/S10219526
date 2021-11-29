using System;

namespace S10219526_StudentApp
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public static string Header => $"{"ID",-5}{"Name",-15}{"Tel",-10}{"Date of Birth",-15}";

        public Student(int id, string name, string tel, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            Tel = tel;
            DateOfBirth = dateOfBirth;
        }

        public Student(string line)
        {
            var split = line.Split(",");
            Id = int.Parse(split[0]);
            Name = split[1];
            Tel = split[2];
            DateOfBirth = DateTime.Parse(split[3], Defaults.Culture);
        }

        public override string ToString()
        {
            return $"{Id,-5}{Name,-15}{Tel,-10}{DateOfBirth.ToShortDateString(),-15}";
        }
    }
}