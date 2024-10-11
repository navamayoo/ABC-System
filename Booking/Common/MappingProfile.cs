using AutoMapper;
using Booking.DTO.Country;
using Booking.DTO.States;
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

            CreateMap<States, CreateStatesDTO>().ReverseMap();
            CreateMap<States, UpdateStatesDTO>().ReverseMap();
            CreateMap<States, StatesDTO >().ReverseMap();

        }
    }
}
