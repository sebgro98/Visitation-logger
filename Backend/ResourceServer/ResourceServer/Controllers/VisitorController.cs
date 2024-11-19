using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using SharedModels.Models;
using ResourceServer.DTO;
using System.Text.RegularExpressions;

namespace ResourceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IVisitorAccountRepository _visitorAccountRepository;
        private static readonly Regex SsnRegex = new Regex("^\\d{8}-\\d{4}$");
        private static readonly Regex OnlyLettersAndNumbersRegex = new Regex(@"^[a-zA-Z0-9]+$");

        public VisitorController(IVisitorRepository visitorRepository, IVisitorAccountRepository visitorAccountRepository)
        {
            _visitorAccountRepository = visitorAccountRepository;
            _visitorRepository = visitorRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Visitor>> CreateVisitor([FromBody] VisitorDTOPost visitorDto)
        {
            ActionResult visitorValidationResult = ValidateVisitorData(visitorDto);
            if (visitorValidationResult is BadRequestObjectResult)
            {
                return visitorValidationResult;
            }

            var createdVisitor = await _visitorRepository.CreateVisitor(visitorDto);
            var visitorAccount = await _visitorAccountRepository.GetVisitorAccountById(visitorDto.VisitorAccountId);

            if (visitorAccount == null)
            {
                return NotFound("Account ID must match an existing acccount ID.");
            }
            else if (visitorAccount.VisitorId != null)
            {
                return NotFound("That account ID is already connected to another user.");
            }

            if (createdVisitor == null)
            {
                return BadRequest("Country not found");
            }

            await _visitorAccountRepository.UpdateVisitorAccount(visitorAccount.Id, new VisitorAccountDto
            {
                AccountTypeId = visitorAccount.AccountTypeId,
                PurposeTypeId = visitorAccount.PurposeTypeId,
                StartDate = visitorAccount.StartDate,
                EndDate = visitorAccount.EndDate,
                UserName = visitorAccount.Username,
                Password = visitorAccount.Password,
                VisitorId = createdVisitor.Id
            });
            
            return Ok(createdVisitor);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Visitor>> GetVisitorById(Guid id)
        {
            var visitor = await _visitorRepository.GetVisitorById(id);

            if(visitor == null)
            {
                return NotFound();
            }

            return Ok(visitor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Visitor>> UpdateVisitor(Guid id, [FromBody] VisitorDTOPut visitorPutDTO)
        {
            ActionResult visitorValidationResult = ValidateVisitorData(visitorPutDTO); 
            if (visitorValidationResult is BadRequestObjectResult)
            {
                return visitorValidationResult;
            }

            var visitorToUpdate = await _visitorRepository.UpdateVisitor(id, visitorPutDTO);

            if(visitorToUpdate == null)
            {
                return NotFound();
            }

            return Ok(visitorPutDTO);
        }

        //Add whitespace check
        private ActionResult ValidateVisitorData(IVisitorDTO iVisitorDto)
        {
            if (iVisitorDto.FullName.Length < 4 || iVisitorDto.FullName.Length > 50 || !iVisitorDto.FullName.All(char.IsLetter))
            {
                return BadRequest("Name must be at least 4 and at most 50 characters long, and can only contain letters.");
            }
            if (!SsnRegex.IsMatch(iVisitorDto.SSN))
            {
                return BadRequest("SSN/Personal number must have this format: YYYYMMDD-XXXX.");
            }
            if (iVisitorDto.PassportNo.Length > 9 || !OnlyLettersAndNumbersRegex.IsMatch(iVisitorDto.PassportNo))
            {
                return BadRequest("Passport number cannot be longer than 9 characters and can only contain letters and numbers.");
            }
            if (iVisitorDto.Company.Length > 50 || !OnlyLettersAndNumbersRegex.IsMatch(iVisitorDto.Company))
            {
                return BadRequest("Company name cannot be longer than 50 characters and can only contain letters and numbers." + _visitorRepository.GetCountry(iVisitorDto.CountryName));
            }
            if (iVisitorDto.City.Length > 50 || !iVisitorDto.City.All(char.IsLetter))
            {
                return BadRequest("City name cannot be longer than 50 characters and can only contain letters.");
            }
            return Ok();
        }
    }
}
