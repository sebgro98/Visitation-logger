using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using SharedModels.Models;
using ResourceServer.DTO;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;



namespace ResourceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IVisitorAccountRepository _visitorAccountRepository; 
        private static readonly Regex FullnameRegex = new Regex("^[a-zA-Z]{4,50}( [a-zA-Z]{4,50})*$");
        private static readonly Regex SsnRegex = new Regex("^\\d{8}-\\d{4}$");
        private static readonly Regex PassportNoRegex = new Regex("^[A-Z0-9]{8,9}$");
        private static readonly Regex CompanyNameRegex = new Regex("^[a-zA-Z0-9@&\\-_ ]{1,50}$");
        private static readonly Regex CityRegex = new Regex("^[a-zA-Z ]{1,50}$");

        public VisitorController(IVisitorRepository visitorRepository, IVisitorAccountRepository visitorAccountRepository)
        {
            _visitorAccountRepository = visitorAccountRepository;
            _visitorRepository = visitorRepository;
        }

        [Authorize(Roles = "MasterAdmin, Visitor")]
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


            if (createdVisitor == null)
            {
              return BadRequest("Country not found");
             }
             
            if (visitorAccount == null)
            {
                return NotFound("Account ID must match an existing acccount ID.");
            }
            
            else if (visitorAccount.VisitorId != null)
            {
                return NotFound("That account ID is already connected to another user.");
            }
            
            await _visitorAccountRepository.UpdateVisitorAccount(visitorAccount.Id, new VisitorAccountPutDTO
            {
                AccountTypeId = visitorAccount.AccountTypeId,
                PurposeTypeId = visitorAccount.PurposeTypeId,
                StartDate = visitorAccount.StartDate,
                EndDate = visitorAccount.EndDate,
                Username = visitorAccount.Username,
                Password = visitorAccount.Password,
                VisitorId = createdVisitor.Id,
                NodeId = visitorAccount.NodeId
            });

            return Ok(createdVisitor);
        }

        [Authorize(Roles = "MasterAdmin, LoggAdmin")]
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

        [Authorize(Roles = "MasterAdmin")]
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
            if (!FullnameRegex.IsMatch(iVisitorDto.FullName))
            {
                return BadRequest("Name must be at least 4 and at most 50 characters long, and can only contain letters.");
            }
            if (!SsnRegex.IsMatch(iVisitorDto.SSN))
            {
                return BadRequest("SSN/Personal number must have this format: YYYYMMDD-XXXX.");
            }
            if (!PassportNoRegex.IsMatch(iVisitorDto.PassportNo))
            {
                return BadRequest("Passport number cannot be shorter than 8 or longer than 9 characters and can only contain letters and numbers.");
            }
            if (!CompanyNameRegex.IsMatch(iVisitorDto.Company))
            {
                return BadRequest("Company name cannot be longer than 50 characters and can only contain letters, numbers, at signs, ampersands, hyphens and underscores.");
            }
            if (!CityRegex.IsMatch(iVisitorDto.City))
            {
                return BadRequest("City name cannot be longer than 50 characters and can only contain letters.");
            }
            return Ok();
        }
    }
}
