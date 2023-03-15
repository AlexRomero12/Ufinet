namespace ufinet.Models
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public int Population { get; set; }
        public List<HotelDto> Hotels { get; set; }
        public List<RestaurantDto> Restaurants { get; set; }
    }
}
