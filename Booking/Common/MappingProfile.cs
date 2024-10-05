using AutoMapper;
using Booking.DTO.Country;
using Booking.Models;

namespace Booking.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Sourse Destination
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();
        }
    }
}
