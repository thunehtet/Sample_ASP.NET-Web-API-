using HotelListing.API.Core.Contracts;
using SampleProject.Data;

namespace SampleProject.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        public HotelsRepository(HotelListingDbContext context) : base(context)
        {

        }

    }
}
