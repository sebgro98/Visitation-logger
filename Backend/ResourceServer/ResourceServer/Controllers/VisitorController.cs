using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using SharedModels.Models;
using ResourceServer.DTO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace ResourceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IVisitorAccountRepository _visitorAccountRepository;
        private static readonly Regex SsnRegex = new Regex("^\\d{3}-\\d{2}-\\d{4}$");
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

        private ActionResult ValidateVisitorData(IVisitorDTO iVisitorDto)
        {
            if (iVisitorDto.FullName.Length < 4 || iVisitorDto.FullName.Length > 20 || !iVisitorDto.FullName.All(char.IsLetter))
            {
                return BadRequest("Name must be at least 4 and at most 20 characters long, and can only contain letters.");
            }
            else if (!SsnRegex.IsMatch(iVisitorDto.SSN))
            {
                return BadRequest("Social security number must have this format: 123-45-6789.");
            }
            else if (!Equals(iVisitorDto.CountryName.ToLower(), "sweden") && !Equals(iVisitorDto.CountryName.ToLower(), "norway"))
            {
                return BadRequest("Country must be either Norway or Sweden.");
            }
            else if (iVisitorDto.PassportNo.Length > 9 || !OnlyLettersAndNumbersRegex.IsMatch(iVisitorDto.PassportNo))
            {
                return BadRequest("Passport number cannot be longer than 9 characters and can only contain letters and numbers.");
            }
            else if (iVisitorDto.Company.Length > 20 || OnlyLettersAndNumbersRegex.IsMatch(iVisitorDto.Company))
            {
                return BadRequest("Company name cannot be longer than 20 characters and can only contain letters and numbers.");
            }
            else if (iVisitorDto.City.Length > 20 || !iVisitorDto.City.All(char.IsLetter))
            {
                return BadRequest("City name cannot be longer than 20 characters and can only contain letters.");
            }
            return Ok();
        }
    }
}
