using ufinet.Entities;
using Microsoft.EntityFrameworkCore;
using ufinet.Services.Interfaces;

namespace ufinet.Services
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountries(string filter = null, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Countries
                .Include(c => c.Hotels)
                .Include(c => c.Restaurants)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                query = query.Where(c =>
                    c.Name.Contains(filter) || c.ISOCode.Contains(filter) ||
                    c.Hotels.Any(h => h.Name.Contains(filter)) || c.Restaurants.Any(r => r.Name.Contains(filter)));
            }

            var countries = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return countries;
        }

        public async Task<int> GetTotalCount(string filter = null)
        {
            var query = _context.Countries.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                query = query.Where(c =>
                    c.Name.Contains(filter) || c.ISOCode.Contains(filter) ||
                    c.Hotels.Any(h => h.Name.Contains(filter)) || c.Restaurants.Any(r => r.Name.Contains(filter)));
            }

            var totalCount = await query.CountAsync();

            return totalCount;
        }
    }
}