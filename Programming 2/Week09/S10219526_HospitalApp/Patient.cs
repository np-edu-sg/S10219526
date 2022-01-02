namespace S10219526_HospitalApp
{
    public class Patient : Person
    {
        public Room WardedAt { get; set; }

        public Patient(string nric, string name, Room room) : base(nric, name)
        {
            WardedAt = room;
        }

        public override string ToString()
        {
            return $"{Nric,-15}{Name,-20}{WardedAt.Location,-15}{WardedAt.WardClass}";
        }

        public string ToCSV()
        {
            return $"{Nric},{Name},{WardedAt.Location}";
        }
    }
}