namespace S10219526_HospitalApp
{
    public class Person
    {
        public string Nric { get; set; }
        public string Name { get; set; }

        public Person(string nric, string name)
        {
            Nric = nric;
            Name = name;
        }
    }
}