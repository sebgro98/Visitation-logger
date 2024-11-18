using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using SharedModels.Models;
using ResourceServer.DTO;
using Microsoft.AspNetCore.Authorization;

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

    }
}
