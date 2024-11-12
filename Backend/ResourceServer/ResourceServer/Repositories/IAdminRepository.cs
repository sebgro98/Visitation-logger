using Microsoft.EntityFrameworkCore;
using ResourceServer.Model;

namespace ResourceServer.Repositories{
	public interface IAdminRepository{
		Task<IEnumerable<Admin>> GetAll();
		Task<Admin> GetById(Guid id);
		Task<Admin> Insert(Admin obj);
		Task<Admin> Update(Admin obj);
		Task<Admin> Delete(object id);
        Task<int> SaveChangesAsync();
        DbSet<Admin> Table { get; }
	}
}