using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SampleProject.Contracts;
using SampleProject.Data;
using SampleProject.Models.Country;

namespace SampleProject.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;

        public CountriesRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<Country> GetDetails(int id)
        {
            var country = await _context.Countries.Include(q => q.Hotels).
                FirstOrDefaultAsync(q=>q.Id==id);

            return country;
        }
    }
}
