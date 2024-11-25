using ResourceServer.DTO;
using SharedModels.Models;

namespace ResourceServer.Repositories
{
    public interface IVisitorAccountRepository
    {
        Task<IEnumerable<VisitorAccount>> GetAllVisitorAccounts();
        Task<VisitorAccount> GetVisitorAccountById(Guid id);
        Task<VisitorAccount> UpdateVisitorAccount(Guid id, VisitorAccountPutDTO dto);
        Task<VisitorAccount> CreateVisitorAccount(VisitorAccountDTO dto);
        Task DeleteVisitorAccount(int id);
        Task<ByPageVisitorAccountDTO> GetVisitorAccountByPage(int pageNumber, int pageSize);
    }
}