namespace S10219526_ShippingApp
{
    public class Customer
    {
        public string Name { get; set; }
        public string Tel { get; set; }
        public ShippingAddr Addr { get; set; }

        public Customer()
        {
        }

        public Customer(string name, string tel, ShippingAddr addr)
        {
            Name = name;
            Tel = tel;
            Addr = addr;
        }

        public override string ToString()
        {
            return $"{Name,-10}{Tel,-12}{Addr.Country,-15}{Addr.Street,-20}";
        }
    }
}