using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using SharedModels.Models;
using ResourceServer.DTO;

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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStatus(Guid id, [FromBody] StatusCheckOutDTO statusCheckOutDto)
        {
            Status updateStatus =
                await _statusRepository.UpdateStatus(id, statusCheckOutDto);

            if (updateStatus == null)
            {
                return NotFound();
            }

            return Ok(updateStatus);
        }

        [HttpGet("{visitorId}/checkin-status")]
        public async Task<IActionResult> GetCheckInStatus(Guid visitorId)
        {
            Status latestStatus = await _statusRepository.GetCheckInStatus(visitorId);

            if (latestStatus == null) {
                return NotFound();
            }

            if (latestStatus != null && latestStatus.CheckInTime.Date == DateTime.UtcNow.Date)
            {
                return Ok(new
                {
                    CheckedInToday = true,
                    StatusId = latestStatus.Id,
                    CheckInTime = latestStatus.CheckInTime
                });
            }

            return Ok(new { CheckedInToday = false });
        }

    }
}
