using AuthenticationServer.Data;
using AuthenticationServer.Model;
using Microsoft.EntityFrameworkCore;

namespace ResourceServer.Repository
{
    public class VisitorAccountRepository : IVisitorAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public VisitorAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VisitorAccount> GetVisitorAccountWithVisitor(Guid id)
        {
            return await _context.VisitorAccounts
                .Include(va => va.Visitor)
                .FirstOrDefaultAsync(va => va.Id == id);
        }


        public async Task<IEnumerable<VisitorAccount>> GetAllVisitorAccounts()
        {
            return await _context.VisitorAccounts.ToListAsync();
        }

        public async Task<VisitorAccount> GetVisitorAccountById(int id)
        {
            return await _context.VisitorAccounts.FindAsync(id);
        }



        public async Task<VisitorAccount> UpdateVisitorAccount(int id, VisitorAccount visitorAccount)
        {
            var visitorAccountToUpdate = await _context.VisitorAccounts.FindAsync(id);

            if (visitorAccountToUpdate == null)
            {
                return null;
            }
            /*
            * Update the visitorAccountToUpdate object with the new values
            */
            _context.VisitorAccounts.Update(visitorAccountToUpdate);
            await _context.SaveChangesAsync();

            return visitorAccountToUpdate;
        }


        public async Task DeleteVisitorAccount(int id)
        {
            var visitorAccount = await _context.VisitorAccounts.FindAsync(id);
            if (visitorAccount != null)
            {
                _context.VisitorAccounts.Remove(visitorAccount);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<VisitorAccount> CreateVisitorAccount(VisitorAccount visitorAccount)
        {
            _context.VisitorAccounts.Add(visitorAccount);
            await _context.SaveChangesAsync();
            return visitorAccount;
        }
    }
}