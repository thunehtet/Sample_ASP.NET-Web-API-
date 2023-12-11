using AutoMapper;
using SampleProject.Data;
using SampleProject.Models.Country;
using SampleProject.Models.Hotel;

namespace SampleProject.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountry>().ReverseMap();
            CreateMap<Country, GetCountry>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountry>().ReverseMap();

            CreateMap<Hotel, HotelDto>().ReverseMap();

        }
    }
}
