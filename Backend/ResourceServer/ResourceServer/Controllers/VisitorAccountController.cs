using ResourceServer.DTO;
using SharedModels.Models;
using SharedModels.Hasher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceServer.Repositories;

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

        [HttpPost]
        public async Task<IActionResult> CreateVisitorAccount([FromBody] VisitorAccountDto visitorAccountDto)
        {
            if (visitorAccountDto == null)
            {
                return BadRequest("Invalid data.");
            }

            //Hash password
            var hashedPassword = Hasher.HashPassword(visitorAccountDto.Password);

            var visitorAccount = new VisitorAccount
            {
                Id = Guid.NewGuid(),
                Username = visitorAccountDto.UserName,
                Password = hashedPassword,
                StartDate = visitorAccountDto.StartDate,
                EndDate = visitorAccountDto.EndDate,
                PurposeTypeId = visitorAccountDto.PurposeTypeId,
                VisitorId = visitorAccountDto.VisitorId,
                AccountTypeId = visitorAccountDto.AccountTypeId
            };

            // Save the new visitor account
            await _visitorAccountRepository.CreateVisitorAccount(visitorAccount);
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

    }
}