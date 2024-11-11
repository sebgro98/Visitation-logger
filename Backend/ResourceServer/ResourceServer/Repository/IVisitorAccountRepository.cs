using ResourceServer.Model;

namespace ResourceServer.Repository
{
    public interface IVisitorAccountRepository
    {
        Task<IEnumerable<VisitorAccount>> GetAllVisitorAccounts();
        Task<VisitorAccount> GetVisitorAccountById(int id);
        Task<VisitorAccount> UpdateVisitorAccount(int id, VisitorAccount visitorAccount);
        Task<VisitorAccount> CreateVisitorAccount(VisitorAccount visitorAccount);
        Task DeleteVisitorAccount(int id);
    }
}