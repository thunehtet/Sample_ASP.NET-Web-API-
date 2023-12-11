using SampleProject.Data;
using SampleProject.Models.Country;

namespace SampleProject.Contracts
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}
