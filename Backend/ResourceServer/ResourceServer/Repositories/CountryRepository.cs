using Microsoft.EntityFrameworkCore;
using ResourceServer.Data;
using SharedModels.Models;

namespace ResourceServer.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await _context.Countries.ToListAsync();
        }
    }
}
