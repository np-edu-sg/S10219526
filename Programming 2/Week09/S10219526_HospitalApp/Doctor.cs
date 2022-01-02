using System.Collections.Generic;

namespace S10219526_HospitalApp
{
    public class Doctor : Person
    {
        public string Department { get; set; }
        public List<Patient> PatientList { get; set; }

        public Doctor(string nric, string name, string department) : base(nric, name)
        {
            Department = department;
            PatientList = new List<Patient>();
        }

        public void AddPatient(Patient patient)
        {
            PatientList.Add(patient);
        }

        public void RemovePatient(Patient patient)
        {
            PatientList.Remove(patient);
        }

        public override string ToString()
        {
            return $"{Nric,-15}{Name,-10}{Department,-10}";
        }

        public string ToStringWithPatients()
        {
            var s = "";

            s += $"{Nric,-15}{Name,-10}{Department,-15}";

            if (PatientList.Count == 0)
            {
                s += "(No patients)";
                return s;
            }

            for (var idx = 0; idx < PatientList.Count; idx++)
            {
                if (idx == 0) s += $"{PatientList[idx].Name}\n";
                else s += $"{"",-40}{PatientList[idx].Name}\n";
            }

            return s;
        }
    }
}