using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceServer.DTO;
using ResourceServer.Repositories;
using SharedModels.Models;

namespace ResourceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetAllStatuses()
        {
            var status = await _statusRepository.GetAllStatuses();

            return Ok(status);
        }

        [HttpGet("/filter")]
        public async Task<ActionResult<IEnumerable<Status>>> GetFilteredStatuses(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] FilterDTO dto
        )
        {
            //Returns IQueryable<Status> which will not execute the db query until calling toListAsync() 
            //(after filtering and pagination)
            var filteredStatuses = _statusRepository.GetAllStatusesForFiltering();

            //Filtering
            if (dto.NodeId != null)
            {
                filteredStatuses = filteredStatuses.Where(status => status.NodeId == dto.NodeId);
            }

            if (dto.CheckInTime != null)
            {
                filteredStatuses = filteredStatuses.Where(status =>
                    status.CheckInTime >= dto.CheckInTime
                    && !string.IsNullOrEmpty(status.CheckInSign)
                );
            }

            if (dto.CheckOutTime != null)
            {
                filteredStatuses = filteredStatuses.Where(status =>
                    status.CheckOutTime <= dto.CheckOutTime
                    && !string.IsNullOrEmpty(status.CheckOutSign)
                );
            }

            //Pagination
            filteredStatuses = filteredStatuses.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            //Database filtering and pagination executes
            var statusList = await filteredStatuses.ToListAsync();

            return Ok(statusList);
        }
    }
}
