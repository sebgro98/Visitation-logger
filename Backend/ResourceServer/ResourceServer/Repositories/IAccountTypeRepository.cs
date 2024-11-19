using SharedModels.Models;

namespace ResourceServer.Repositories
{
    public interface IAccountTypeRepository
    {
        Task<IEnumerable<AccountType>> GetAll();
    }
}
