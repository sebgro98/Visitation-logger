using Microsoft.EntityFrameworkCore;
using ResourceServer.Data;
using ResourceServer.DTO;
using SharedModels.Models;
using SharedModels.Hasher;
using Npgsql;

namespace ResourceServer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private ApplicationDbContext _context;
        

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
           
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin> GetById(Guid id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task<Admin> Create(AdminDTO dto)
        {
            try
            {
                var hashedPassword = Hasher.HashPassword(dto.Password);

                var admin = new Admin
                {
                    Id = Guid.NewGuid(),
                    Username = dto.Username.ToLower(),
                    Password = hashedPassword,
                    AccountTypeId = dto.AccountTypeId,
                    NodeId = dto.NodeId,
                    FullName = dto.FullName
                };

                _context.Admins.Add(admin);
                await _context.SaveChangesAsync();

                return admin;
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


        public async Task<Admin> Update(Guid id, AdminPutDTO dto)
        {
            try
            {
                var adminToBeUpdated = await GetById(id);

                if (adminToBeUpdated == null)
                {
                    return null;
                }

                if(dto.Password != null && dto.Password != "")
                {
                    var hashedPassword = Hasher.HashPassword(dto.Password);
                    adminToBeUpdated.Password = hashedPassword;
                }

                adminToBeUpdated.Username = dto.Username.ToLower();
                adminToBeUpdated.AccountTypeId = dto.AccountTypeId;
                adminToBeUpdated.NodeId = dto.NodeId;
                adminToBeUpdated.FullName = dto.FullName;

                _context.Admins.Update(adminToBeUpdated);
                await _context.SaveChangesAsync();

                return adminToBeUpdated;
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

        public async Task<bool> Delete(Guid id)
        {
            var adminToBeDeleted = await GetById(id);

            if (adminToBeDeleted == null)
            {
                return false;
            }

            _context.Admins.Remove(adminToBeDeleted);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ByPageAdminDTO> GetAdminsByPage(int pageNumber, int pageSize)
        {
            var admins =  await _context.Admins
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            
            int totalSize = await _context.Admins.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalSize / pageSize);

            ByPageAdminDTO byPageAdminDto = new ByPageAdminDTO
            {
                Data = admins,
                totalAmountOfItems = totalSize,
                totalPages = totalPages,
            };
            return byPageAdminDto;
        }
    }
}
