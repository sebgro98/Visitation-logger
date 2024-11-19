using Microsoft.EntityFrameworkCore;
using ResourceServer.Data;
using SharedModels.Models;

namespace ResourceServer.Repositories
{
    public class PurposeTypesRepository : IPurposeTypesRepository
    {
        private readonly ApplicationDbContext _context;

        public PurposeTypesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurposeType>> GetPurposeTypes()
        {
            return await _context.PurposeTypes.ToListAsync();
        }
    }
}
