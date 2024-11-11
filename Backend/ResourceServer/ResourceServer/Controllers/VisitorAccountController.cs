using ResourceServer.DTO;
using ResourceServer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceServer.Repository;

namespace ResourceServer.Controller
{
    [Route("[controller]")]

    public class VisitorAccountController : ControllerBase
    {
        private readonly IVisitorAccountRepository _visitorAccountRepository;


        public VisitorAccountController(IVisitorAccountRepository visitorAccountuserRepository)
        {
            _visitorAccountRepository = visitorAccountuserRepository;
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
                Id = Guid.NewGuid(), // Assign a new unique ID if it's generated server-side
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
        public async Task<ActionResult<IEnumerable<VisitorAccount>>> GetUsers()
        {
            var visitorAccounts = await _visitorAccountRepository.GetAllVisitorAccounts();
            return Ok(visitorAccounts);
        }


    }
}