using ResourceServer.Data;
using SharedModels.Models;
using Microsoft.EntityFrameworkCore;
using ResourceServer.DTO;
using SharedModels.Hasher;

namespace ResourceServer.Repositories
{
    public class VisitorAccountRepository : IVisitorAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public VisitorAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VisitorAccount>> GetAllVisitorAccounts()
        {
            return await _context.VisitorAccounts
                .Include(v => v.Visitor) // Eagerly load the Visitor related entity
                .ToListAsync();
        }

        public async Task<VisitorAccount> GetVisitorAccountById(int id)
        {
            return await _context.VisitorAccounts.FindAsync(id);
        }

        public async Task<VisitorAccount> UpdateVisitorAccount(Guid id, VisitorAccountDto visitorAccountDto)
        {
            var visitorAccountToUpdate = await _context.VisitorAccounts.FindAsync(id);

            if (visitorAccountToUpdate == null)
            {
                return null;
            }

            var hashedPassword = Hasher.HashPassword(visitorAccountDto.Password);
            
            visitorAccountToUpdate.PurposeTypeId = visitorAccountDto.PurposeTypeId;
            visitorAccountToUpdate.Username = visitorAccountDto.UserName;
            visitorAccountToUpdate.Password = hashedPassword;
            visitorAccountToUpdate.StartDate = visitorAccountDto.StartDate;
            visitorAccountToUpdate.EndDate = visitorAccountDto.EndDate;
            visitorAccountToUpdate.VisitorId = visitorAccountDto.VisitorId;
            visitorAccountToUpdate.AccountTypeId = visitorAccountDto.AccountTypeId;

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