using Microsoft.EntityFrameworkCore;
using Npgsql;
using ResourceServer.Data;
using ResourceServer.DTO;
using SharedModels.Hasher;
using SharedModels.Models;
using System.Text.RegularExpressions;

namespace ResourceServer.Repositories
{
    public class VisitorAccountRepository : IVisitorAccountRepository
    {
        private readonly ApplicationDbContext _context;
        private static readonly Regex PasswordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%?&])[A-Za-z\d@$!%?&]{8,}$");

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

        public async Task<VisitorAccount> UpdateVisitorAccount(Guid id, VisitorAccountDto dto)
        {
            try
            {
                var visitorAccountToUpdate = await _context.VisitorAccounts.FindAsync(id);

                if (visitorAccountToUpdate == null)
                {
                    return null;
                }

                var hashedPassword = Hasher.HashPassword(dto.Password);

                visitorAccountToUpdate.PurposeTypeId = dto.PurposeTypeId;
                visitorAccountToUpdate.Username = dto.UserName.ToLower();
                visitorAccountToUpdate.Password = hashedPassword;
                visitorAccountToUpdate.StartDate = dto.StartDate;
                visitorAccountToUpdate.EndDate = dto.EndDate;
                visitorAccountToUpdate.VisitorId = dto.VisitorId;
                visitorAccountToUpdate.AccountTypeId = dto.AccountTypeId;
                visitorAccountToUpdate.NodeId = dto.NodeId;

                _context.VisitorAccounts.Update(visitorAccountToUpdate);
                await _context.SaveChangesAsync();

                return visitorAccountToUpdate;
            }
            catch (DbUpdateException ex)
            {

                if (ex.InnerException is PostgresException postgresEx && postgresEx.SqlState == "23505")
                {

                    throw new Exception("Username is already taken.", ex);
                }


                throw new Exception("An error occurred while creating the admin.", ex);
            }
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
            if (!PasswordRegex.IsMatch(dto.Password))
            {
                return null;
            }

            try
            {
                var hashedPassword = Hasher.HashPassword(dto.Password);

                var visitorAccount = new VisitorAccount
                {
                    Id = Guid.NewGuid(),
                    Username = dto.UserName.ToLower(),
                    Password = hashedPassword,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    PurposeTypeId = dto.PurposeTypeId,
                    VisitorId = dto.VisitorId,
                    AccountTypeId = dto.AccountTypeId,
                    NodeId = dto.NodeId,
                };

                _context.VisitorAccounts.Add(visitorAccount);
                await _context.SaveChangesAsync();
                return visitorAccount;
            }
            catch (DbUpdateException ex)
            {

                if (ex.InnerException is PostgresException postgresEx && postgresEx.SqlState == "23505")
                {

                    throw new Exception("Username is already taken.", ex);
                }


                throw new Exception("An error occurred while creating the admin.", ex);
            }

        }

        public async Task<ByPageVisitorAccountDTO> GetVisitorAccountByPage(int pageNumber, int pageSize) {
            {
               var visitorAccounts = await _context.VisitorAccounts
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                int totalSize = await _context.VisitorAccounts.CountAsync();
                int totalPages = (int)Math.Ceiling((double)totalSize / pageSize);

                ByPageVisitorAccountDTO byPageVisitorAccountDTO = new ByPageVisitorAccountDTO
                {
                    Data = visitorAccounts,
                    totalAmountOfItems = totalSize,
                    totalPages = totalPages,
                };

                return byPageVisitorAccountDTO;
            }                
        }
    }
}
