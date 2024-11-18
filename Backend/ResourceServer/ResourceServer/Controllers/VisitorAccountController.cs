using ResourceServer.DTO;
using SharedModels.Models;
using SharedModels.Hasher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceServer.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace ResourceServer.Controller
{
    [Route("[controller]")]

    public class VisitorAccountController : ControllerBase
    {
        private readonly IVisitorAccountRepository _visitorAccountRepository;


        public VisitorAccountController(IVisitorAccountRepository visitorAccountRepository)
        {
            _visitorAccountRepository = visitorAccountRepository;
        }

        [Authorize(Roles = "MasterAdmin")]
        [HttpPost]
        public async Task<IActionResult> CreateVisitorAccount([FromBody] VisitorAccountDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data.");
            }

            var visitorAccount = await _visitorAccountRepository.CreateVisitorAccount(dto);
            return Ok(visitorAccount);
        }

        [Authorize(Roles = "MasterAdmin, LoggAdmin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitorAccount>>> GetVisitorAccounts()
        {
            var visitorAccounts = await _visitorAccountRepository.GetAllVisitorAccounts();

            return Ok(visitorAccounts);
        }

        [Authorize(Roles = "MasterAdmin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVisitorAccount(Guid id, [FromBody] VisitorAccountDto visitorAccountDto)
        {
            VisitorAccount updateVisitorAccount =
                await _visitorAccountRepository.UpdateVisitorAccount(id, visitorAccountDto);

            if (updateVisitorAccount == null)
            {
                return NotFound();
            } 

            return Ok(updateVisitorAccount);
        }

    }
}