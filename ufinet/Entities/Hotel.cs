using ufinet.Entities;

namespace ufinet.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}