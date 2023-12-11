using SampleProject.Models.Hotel;

namespace SampleProject.Models.Country
{
    public class CountryDto: BaseCountry
    {
        public int Id { get; set; }
        public List<HotelDto> Hotels { get; set; }
    }
}
