using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace S10219526_HospitalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var roomList = new List<Room>();
            var patientList = new List<Patient>();
            var doctorList = new List<Doctor>();

            InitData(roomList, doctorList);

            Console.WriteLine();
            Console.WriteLine("Rooms:");

            Console.WriteLine($"{"Location",-10}{"Ward class",-10}");
            foreach (var room in roomList) Console.WriteLine(room);

            Console.WriteLine();
            Console.WriteLine("Doctors:");

            Console.WriteLine($"{"Nric",-15}{"Name",-10}{"Department",-10}");
            foreach (var doctor in doctorList) Console.WriteLine(doctor);

            CreatePatients(patientList, roomList);

            Console.WriteLine();
            Console.WriteLine("Patients:");

            Console.WriteLine($"{"Nric",-15}{"Name",-20}{"Ward location",-15}Ward class");
            foreach (var patient in patientList) Console.WriteLine(patient);

            AssignPatientsToDoctors(patientList, doctorList);

            Console.WriteLine();
            Console.WriteLine("Patients under the care of each doctor:");
            Console.WriteLine($"{"Nric",-15}{"Name",-10}{"Department",-15}Patients");
            foreach (var doctor in doctorList) Console.WriteLine(doctor.ToStringWithPatients());

            Console.WriteLine();
            RemovePatientFromDoctor(doctorList);

            Console.WriteLine();
            Console.WriteLine("Patients under the care of each doctor:");
            Console.WriteLine($"{"Nric",-15}{"Name",-10}{"Department",-15}Patients");
            foreach (var doctor in doctorList) Console.WriteLine(doctor.ToStringWithPatients());
            
            Console.WriteLine();

            AddNewPatient(patientList, roomList);
        }

        public static void AddNewPatient(List<Patient> patientList, List<Room> roomList)
        {
            Console.Write("Enter the Nric: ");
            var nric = Console.ReadLine();

            Console.Write("Enter the name: ");
            var name = Console.ReadLine();

            Room room;
            while (true)
            {
                Console.Write("Enter the room: ");
                var input = Console.ReadLine();
                if (roomList.Exists(r => r.Location == input))
                {
                    room = roomList.Find(r => r.Location == input);
                    break;
                }

                Console.WriteLine("Invalid room");
            }

            var patient = new Patient(nric, name, room);
            patientList.Add(patient);
            
            File.AppendAllText("./Assets/Patients.csv", "\n" + patient.ToCSV());
        }

        public static void RemovePatientFromDoctor(List<Doctor> doctorList)
        {
            while (true)
            {
                Console.Write("Enter patient Nric: ");
                var input = Console.ReadLine();

                var doctor = doctorList.Find(d => d.PatientList.Exists(p => p.Nric == input));
                if (doctor is null) continue;

                doctor.PatientList.RemoveAll(p => p.Nric == input);
                break;
            }
        }

        public static void AssignPatientsToDoctors(List<Patient> patientList, List<Doctor> doctorList)
        {
            var mappingStrings = File.ReadAllLines("./Assets/PatientsToDoctor.csv");

            foreach (var mappingString in mappingStrings[1..])
            {
                var split = mappingString.Split(",");

                var doctor = doctorList.Find(d => d.Nric == split[2]);
                if (doctor is null) continue;

                var patient = patientList.Find(p => p.Nric == split[0]);

                doctor.PatientList.Add(patient);
            }
        }

        public static void CreatePatients(List<Patient> patientList, List<Room> roomList)
        {
            var patientStrings = File.ReadAllLines("./Assets/Patients.csv");

            foreach (var patientString in patientStrings[1..])
            {
                var split = patientString.Split(",");
                var room = roomList.Find(r => r.Location == split[2]);
                if (room is null) continue;

                patientList.Add(new Patient(split[0], split[1], room));
            }
        }

        public static void InitData(List<Room> roomList, List<Doctor> doctorList)
        {
            roomList.Add(new Room("#01-01", "C"));
            roomList.Add(new Room("#02-02", "B"));
            roomList.Add(new Room("#03-03", "A"));
            roomList.Add(new Room("#04-04", "A"));

            doctorList.Add(new Doctor("S1234567A", "Tom", "Pediatrics"));
            doctorList.Add(new Doctor("S2345678A", "Champ", "Oncology"));
            doctorList.Add(new Doctor("S3456789B", "Terry", "Cardiology"));
        }
    }
}