using SharedModels.Models;
using ResourceServer.DTO;

namespace ResourceServer.Repositories{
	public interface IAdminRepository{
		Task<IEnumerable<Admin>> GetAll();
		Task<Admin> GetById(Guid id);
		Task<Admin> Create(AdminDTO dto);
		Task<Admin> Update(Guid id, AdminPutDTO dto);
		Task<bool> Delete(Guid id);
		Task<ByPageAdminDTO> GetAdminsByPage(int pageNumber, int pageSize);
    }
}