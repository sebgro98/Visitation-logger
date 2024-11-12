using ResourceServer.DTO;
using ResourceServer.Model;
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

            
            var visitorAccount = new VisitorAccount
            {
                Id = Guid.NewGuid(),
                UserName = visitorAccountDto.UserName,
                Password = visitorAccountDto.Password,
                StartDate = visitorAccountDto.StartDate,
                EndDate = visitorAccountDto.EndDate,
                PurposeTypeId = visitorAccountDto.PurposeTypeId,
                VisitorId = visitorAccountDto.VisitorId
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

    }
}