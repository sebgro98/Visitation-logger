using ResourceServer.DTO;
using SharedModels.Models;

namespace ResourceServer.Repositories
{
    public interface IVisitorAccountRepository
    {
        Task<IEnumerable<VisitorAccount>> GetAllVisitorAccounts();
        Task<VisitorAccount> GetVisitorAccountById(int id);
        Task<VisitorAccount> UpdateVisitorAccount(Guid id, VisitorAccountDto visitorAccountDto);
        Task<VisitorAccount> CreateVisitorAccount(VisitorAccount visitorAccount);
        Task DeleteVisitorAccount(int id);
    }
}