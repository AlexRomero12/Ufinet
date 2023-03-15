using AutoMapper;
using ufinet.Entities;
using ufinet.Models;

namespace ufinet
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>()
                .ForMember(dest => dest.Hotels, opt => opt.MapFrom(src => src.Hotels))
                .ForMember(dest => dest.Restaurants, opt => opt.MapFrom(src => src.Restaurants));

            CreateMap<Hotel, HotelDto>();
            CreateMap<Restaurant, RestaurantDto>();
        }
    }
}
