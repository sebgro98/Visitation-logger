using Microsoft.EntityFrameworkCore;
using SharedModels.Models;
using ResourceServer.DTO;

namespace ResourceServer.Repositories{
	public interface IAdminRepository{
		Task<IEnumerable<Admin>> GetAll();
		Task<Admin> GetById(Guid id);
		Task<Admin> Insert(Admin obj);
		Task<Admin> Update(Guid id, AdminDTO dto);
		Task<bool> Delete(Guid id);
        Task<int> SaveChangesAsync();
        // DbSet<Admin> Table { get; }
	}
}