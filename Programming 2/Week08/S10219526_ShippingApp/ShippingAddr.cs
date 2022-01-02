namespace S10219526_ShippingApp
{
    public class ShippingAddr
    {
        public string Country { get; set; }
        public string Street { get; set; }

        public ShippingAddr()
        {
        }

        public ShippingAddr(string country, string street)
        {
            Country = country;
            Street = street;
        }
    }
}