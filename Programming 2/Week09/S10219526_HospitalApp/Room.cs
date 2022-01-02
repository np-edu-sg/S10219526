namespace S10219526_HospitalApp
{
    public class Room
    {
        public string Location { get; set; }
        public string WardClass { get; set; }

        public Room(string location, string wardClass)
        {
            Location = location;
            WardClass = wardClass;
        }

        public override string ToString()
        {
            return $"{Location,-10}{WardClass,-10}";
        }
    }
}