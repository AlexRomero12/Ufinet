using ufinet.Entities;

namespace ufinet.Services.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountries(string filter = null, int pageNumber = 1, int pageSize = 10);
        Task<int> GetTotalCount(string filter = null);
    }
}