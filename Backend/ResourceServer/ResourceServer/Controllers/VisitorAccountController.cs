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
            ActionResult visitorAccountValidationResult = ValidateVisitorAccountData(dto);
            if(visitorAccountValidationResult is BadRequestObjectResult)
            {
                return visitorAccountValidationResult;
            }

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
            ActionResult visitorAccountValidationResult = ValidateVisitorAccountData(visitorAccountDto);
            if (visitorAccountValidationResult is BadRequestObjectResult)
            {
                return visitorAccountValidationResult;
            }

            VisitorAccount updateVisitorAccount =
                await _visitorAccountRepository.UpdateVisitorAccount(id, visitorAccountDto);

            if (updateVisitorAccount == null)
            {
                return NotFound();
            } 

            return Ok(updateVisitorAccount);
        }
<<<<<<< HEAD

<<<<<<< HEAD
=======
        
>>>>>>> 3fce37e87dcd80e95ed52cc08b8c09bd145c229b
        private ActionResult ValidateVisitorAccountData(VisitorAccountDto visitorAccountDto)
        {
            if (!usernameRegex.IsMatch(visitorAccountDto.UserName))
            {
                return BadRequest("Username must be at least 4 and at most 50 characters, and can only contain letters, numbers, periods and at signs.");
            }
            if (visitorAccountDto.StartDate > visitorAccountDto.EndDate)
            {
                return BadRequest("Start date must be earlier or the same date as end date.");
            }
            return Ok();
        }
<<<<<<< HEAD
=======
=======

>>>>>>> 3fce37e87dcd80e95ed52cc08b8c09bd145c229b
        [HttpGet("byPage")]
        public async Task<ActionResult<IEnumerable<VisitorAccount>>> GetAdminsByPage([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var visitorAccounts = await _visitorAccountRepository.GetVisitorAccountByPage(pageNumber, pageSize);
            return Ok(visitorAccounts);
        }
<<<<<<< HEAD

>>>>>>> 0200bf13569543be7b7d2c5d2a50ec6801c81c47
=======
>>>>>>> 3fce37e87dcd80e95ed52cc08b8c09bd145c229b
    }
}