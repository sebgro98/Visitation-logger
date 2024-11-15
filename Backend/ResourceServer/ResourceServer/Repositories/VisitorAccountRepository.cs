using Microsoft.EntityFrameworkCore;
using ResourceServer.Data;
using ResourceServer.DTO;
using SharedModels.Hasher;
using SharedModels.Models;

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
            return await _context
                .VisitorAccounts.Include(v => v.Visitor) // Eagerly load the Visitor related entity
                .ToListAsync();
        }

        public async Task<VisitorAccount> GetVisitorAccountById(Guid id)
        {
            return await _context.VisitorAccounts.FindAsync(id);
        }

        public async Task<VisitorAccount> UpdateVisitorAccount(
            Guid id,
            VisitorAccountDto dto
        )
        {
            var visitorAccountToUpdate = await _context.VisitorAccounts.FindAsync(id);

            if (visitorAccountToUpdate == null)
            {
                return null;
            }

            var hashedPassword = Hasher.HashPassword(dto.Password);

            visitorAccountToUpdate.PurposeTypeId = dto.PurposeTypeId;
            visitorAccountToUpdate.Username = dto.UserName;
            visitorAccountToUpdate.Password = hashedPassword;
            visitorAccountToUpdate.StartDate = dto.StartDate;
            visitorAccountToUpdate.EndDate = dto.EndDate;
            visitorAccountToUpdate.VisitorId = dto.VisitorId;
            visitorAccountToUpdate.AccountTypeId = dto.AccountTypeId;

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

        public async Task<VisitorAccount> CreateVisitorAccount(VisitorAccountDto dto)
        {
            var hashedPassword = Hasher.HashPassword(dto.Password);

            var visitorAccount = new VisitorAccount
            {
                Id = Guid.NewGuid(),
                Username = dto.UserName,
                Password = hashedPassword,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                PurposeTypeId = dto.PurposeTypeId,
                VisitorId = dto.VisitorId,
                AccountTypeId = dto.AccountTypeId
            };

            _context.VisitorAccounts.Add(visitorAccount);
            await _context.SaveChangesAsync();
            return visitorAccount;
        }
    }
}
