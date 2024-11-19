using ResourceServer.DTO;
using SharedModels.Models;
using SharedModels.Hasher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceServer.Repositories;
using System.Text.RegularExpressions;

namespace ResourceServer.Controller
{
    [Route("[controller]")]

    public class VisitorAccountController : ControllerBase
    {
        private readonly IVisitorAccountRepository _visitorAccountRepository;
        private static readonly Regex usernameRegex = new Regex("^[a-zA-Z0-9.@]{4,50}$");

        public VisitorAccountController(IVisitorAccountRepository visitorAccountRepository)
        {
            _visitorAccountRepository = visitorAccountRepository;
        }

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitorAccount>>> GetVisitorAccounts()
        {
            var visitorAccounts = await _visitorAccountRepository.GetAllVisitorAccounts();

            return Ok(visitorAccounts);
        }

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

        private ActionResult ValidateVisitorAccountData(VisitorAccountDto visitorAccountDto)
        {
            if (visitorAccountDto.UserName)
            {
                return BadRequest("Invalid data.");
            }
            return Ok();
        }
    }
}