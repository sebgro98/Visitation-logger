using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "MasterAdmin, LoggAdmin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetAllStatuses()
        {
            var status = await _statusRepository.GetAllStatuses();

            return Ok(status);
        }

        [Authorize(Roles = "MasterAdmin, LoggAdmin")]
        [HttpGet("/filter")]
        public async Task<ActionResult<FilterReturnDTO>> GetFilteredStatuses(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] FilterDTO dto
        )
        {
            //Returns IQueryable<Status> which will not execute the db query until calling toListAsync()
            //(after filtering and pagination)
            var filteredStatuses = _statusRepository.GetAllStatusesForFiltering();

            //Filtering
            if (!string.IsNullOrEmpty(dto.NodeId))
            {
                filteredStatuses = filteredStatuses.Where(status =>
                    status.NodeId.ToString().Contains(dto.NodeId)
                );
            }

            if (
                DateTime.TryParseExact(
                    dto.CheckInTime,
                    "yyyy-MM-dd",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out var parsedCheckInTime
                )
            )
            {
                var checkInTimeUtc = DateTime.SpecifyKind(parsedCheckInTime, DateTimeKind.Utc);

                filteredStatuses = filteredStatuses.Where(status =>
                    status.CheckInTime >= checkInTimeUtc
                // && !string.IsNullOrEmpty(status.CheckInSign)
                );
            }

            if (
                DateTime.TryParseExact(
                    dto.CheckOutTime,
                    "yyyy-MM-dd",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out var parsedCheckOutTime
                )
            )
            {
                var checkOutTimeUtc = DateTime.SpecifyKind(parsedCheckOutTime, DateTimeKind.Utc);

                filteredStatuses = filteredStatuses.Where(status =>
                    status.CheckOutTime >= checkOutTimeUtc
                // && !string.IsNullOrEmpty(status.CheckInSign)
                );
            }

            if (!string.IsNullOrEmpty(dto.VisitorName))
            {
                filteredStatuses = filteredStatuses.Where(status =>
                    status
                        .VisitorAccount.Visitor.FullName.ToLower()
                        .Contains(dto.VisitorName.ToLower())
                );
            }

            if (!string.IsNullOrEmpty(dto.VisitorId))
            {
                filteredStatuses = filteredStatuses.Where(status =>
                    status.VisitorAccount.Visitor.Id.ToString().Contains(dto.VisitorId)
                );
            }

            if (!string.IsNullOrEmpty(dto.PurposeName))
            {
                filteredStatuses = filteredStatuses.Where(status =>
                    status
                        .VisitorAccount.PurposeType.Name.ToLower()
                        .Contains(dto.PurposeName.ToLower())
                );
            }

            //Get number of all elements
            int totalSize = await filteredStatuses.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalSize / pageSize); //Round up if it's a decimal number

            //Pagination
            filteredStatuses = filteredStatuses.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            //Database filtering and pagination executes
            var filteredStatusList = await filteredStatuses.ToListAsync();

            //Convert status objects into status return dtos
            List<StatusDTO> filteredStatusDtoList = filteredStatusList
                .Select(status => new StatusDTO(status))
                .ToList();

            FilterReturnDTO returnDTO = new FilterReturnDTO
            {
                StatusList = filteredStatusDtoList,
                TotalNumberOfElements = totalSize,
                TotalNumberOfPages = totalPages
            };

            return Ok(returnDTO);
        }

        [Authorize(Roles = "Visitor")]
        [HttpPost]
        public async Task<IActionResult> CreateStatus([FromBody] StatusCheckInDTO statusCheckInDto)
        {
            if (statusCheckInDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var status = await _statusRepository.CreateStatus(statusCheckInDto);
            return Ok(status);
        }

        [Authorize(Roles = "Visitor")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStatus(
            Guid id,
            [FromBody] StatusCheckOutDTO statusCheckOutDto
        )
        {
            Status updateStatus = await _statusRepository.UpdateStatus(id, statusCheckOutDto);

            if (updateStatus == null)
            {
                return NotFound();
            }

            return Ok(updateStatus);
        }

        [Authorize(Roles = "Visitor")]
        [HttpGet("{visitorId}/checkin-status")]
        public async Task<IActionResult> GetCheckInStatus(Guid VisitorAccountId)
        {
            Status latestStatus = await _statusRepository.GetCheckInStatus(VisitorAccountId);

            if (latestStatus == null)
            {
                return NotFound();
            }

            if (latestStatus != null && latestStatus.CheckInTime.Date == DateTime.UtcNow.Date)
            {
                return Ok(
                    new
                    {
                        CheckedInToday = true,
                        StatusId = latestStatus.Id,
                        CheckInTime = latestStatus.CheckInTime
                    }
                );
            }

            return Ok(new { CheckedInToday = false });
        }
    }
}
