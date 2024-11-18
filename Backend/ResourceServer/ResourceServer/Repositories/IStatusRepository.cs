using ResourceServer.DTO;
using SharedModels.Models;

namespace ResourceServer.Repositories
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetAllStatuses();
        IQueryable<Status> GetAllStatusesForFiltering();
        Task<Status> GetStatusById(Guid id);
        Task<Status> UpdateStatus(Guid id, StatusDTO statusDTO);
        Task<Status> CreateStatus(StatusDTO statusDTO);
        Task DeleteStatus(Guid id);
    }
}
