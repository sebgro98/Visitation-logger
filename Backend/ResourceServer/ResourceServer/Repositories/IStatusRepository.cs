using ResourceServer.DTO;
using SharedModels.Models;

namespace ResourceServer.Repositories
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetAllStatuses();
        Task<Status> GetStatusById(Guid id);
        Task<Status> UpdateStatus(Guid id, StatusCheckOutDTO statusCheckOutDto);
        Task<Status> CreateStatus(StatusCheckInDTO statusCheckInDto);
        Task DeleteStatus(Guid id);

        Task<Status> GetCheckInStatus(Guid visitorId);
    }
}
