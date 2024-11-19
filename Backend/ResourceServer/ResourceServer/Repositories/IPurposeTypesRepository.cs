using SharedModels.Models;

namespace ResourceServer.Repositories
{
    public interface IPurposeTypesRepository
    {
        Task<IEnumerable<PurposeType>> GetPurposeTypes();
    }
}
