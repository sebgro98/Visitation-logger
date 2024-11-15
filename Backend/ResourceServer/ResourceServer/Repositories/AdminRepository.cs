using Microsoft.EntityFrameworkCore;
using ResourceServer.Data;
using ResourceServer.DTO;
using SharedModels.Models;
using SharedModels.Hasher;

namespace ResourceServer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private ApplicationDbContext _db;
        private DbSet<Admin> _table = null;

        public AdminRepository(ApplicationDbContext db)
        {
            _db = db;
            _table = _db.Set<Admin>();
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<Admin> GetById(Guid id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<Admin> Create(AdminDTO dto)
        {
            var hashedPassword = Hasher.HashPassword(dto.Password);

            var admin = new Admin
            {
                Id = Guid.NewGuid(),
                Username = dto.Username,
                Password = hashedPassword,
                AccountTypeId = dto.AccountTypeId
            };

            _table.Add(admin);
            await _db.SaveChangesAsync();

            return admin;
        }

        public async Task<Admin> Update(Guid id, AdminDTO dto)
        {
            var adminToBeUpdated = await GetById(id);

            if (adminToBeUpdated == null)
            {
                return null;
            }

            var hashedPassword = Hasher.HashPassword(dto.Password);

            adminToBeUpdated.Username = dto.Username;
            adminToBeUpdated.Password = hashedPassword;
            adminToBeUpdated.AccountTypeId = dto.AccountTypeId;

            _table.Attach(adminToBeUpdated);
            _db.Entry(adminToBeUpdated).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return adminToBeUpdated;
        }

        public async Task<bool> Delete(Guid id)
        {
            var adminToBeDeleted = await GetById(id);

            if (adminToBeDeleted == null)
            {
                return false;
            }

            _table.Remove(adminToBeDeleted);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
