using Microsoft.EntityFrameworkCore;
using ResourceServer.Data;
using SharedModels.Models;

namespace ResourceServer.Repositories
{
    public class AccountTypeRepsoitory : IAccountTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountTypeRepsoitory(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccountType>> GetAll()
        {
            return await _context.AccountTypes.ToListAsync();
        }
    }
}
