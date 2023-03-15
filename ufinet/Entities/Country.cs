namespace ufinet.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public int Population { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }
}
