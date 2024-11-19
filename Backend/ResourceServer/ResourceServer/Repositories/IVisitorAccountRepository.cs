using ResourceServer.DTO;
using SharedModels.Models;

namespace ResourceServer.Repositories
{
    public interface IVisitorAccountRepository
    {
        Task<IEnumerable<VisitorAccount>> GetAllVisitorAccounts();
        Task<VisitorAccount> GetVisitorAccountById(Guid id);
        Task<VisitorAccount> UpdateVisitorAccount(Guid id, VisitorAccountDto dto);
        Task<VisitorAccount> CreateVisitorAccount(VisitorAccountDto dto);
        Task DeleteVisitorAccount(int id);

        Task<IEnumerable<VisitorAccount>> GetVisitorAccountByPage(int pageNumber, int pageSize);
    }
}