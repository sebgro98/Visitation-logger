using ResourceServer.DTO;
using SharedModels.Models;
using SharedModels.Hasher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceServer.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;



namespace ResourceServer.Controller
{
    [Route("[controller]")]

    public class VisitorAccountController : ControllerBase
    {
        private readonly IVisitorAccountRepository _visitorAccountRepository;
        private static readonly Regex UsernameRegex = new Regex("^[a-zA-Z0-9]{4,20}$");

        public VisitorAccountController(IVisitorAccountRepository visitorAccountRepository)
        {
            _visitorAccountRepository = visitorAccountRepository;
        }

        [Authorize(Roles = "MasterAdmin")]
        [HttpPost]
        public async Task<IActionResult> CreateVisitorAccount([FromBody] VisitorAccountDTO dto)
        {
            ActionResult visitorAccountValidationResult = ValidateVisitorAccountData(dto);
            if(visitorAccountValidationResult is BadRequestObjectResult)
            {
                return visitorAccountValidationResult;
            }
            
            try
            {
                if (dto == null)
                {
                    return BadRequest("Invalid data.");
                }

                var visitorAccount = await _visitorAccountRepository.CreateVisitorAccount(dto);
                return Ok(visitorAccount);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Username is already taken")
                {
                    return Conflict(new { message = ex.Message });
                }


                return StatusCode(500, new { message = "An error occurred while creating the visitor account.", details = ex.Message });
            }
            
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
        public async Task<ActionResult> UpdateVisitorAccount(Guid id, [FromBody] VisitorAccountPutDTO visitorAccountDto)
        {
            ActionResult visitorAccountValidationResult = ValidateVisitorAccountData(visitorAccountDto);
            if (visitorAccountValidationResult is BadRequestObjectResult)
            {
                return visitorAccountValidationResult;
            }

            try
            {
                VisitorAccount updateVisitorAccount =
                await _visitorAccountRepository.UpdateVisitorAccount(id, visitorAccountDto);

                if (updateVisitorAccount == null)
                {
                    return NotFound();
                }

                return Ok(updateVisitorAccount);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Username is already taken")
                {
                    return Conflict(new { message = ex.Message });
                }


                return StatusCode(500, new { message = "An error occurred while updating the visitor account.", details = ex.Message });
            }


        }

        private ActionResult ValidateVisitorAccountData(IVisitorAccountDTO visitorAccountDto)
        {

            if (!UsernameRegex.IsMatch(visitorAccountDto.Username))
            {
                return BadRequest("Username must be at least 4 and at most 50 characters, and can only contain letters, numbers, periods and at signs.");
            }
            if (DateTime.Compare(visitorAccountDto.StartDate, visitorAccountDto.EndDate) > 0 && DateTime.Compare(visitorAccountDto.StartDate, DateTime.Today) <= 0)
            {
                return BadRequest("Start date must be earlier or the same date as end date.");
            }
            return Ok();
        }

        [Authorize(Roles = "MasterAdmin")]
        [HttpGet("byPage")]
        public async Task<ActionResult<ByPageVisitorAccountDTO>> GetAdminsByPage([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var visitorAccounts = await _visitorAccountRepository.GetVisitorAccountByPage(pageNumber, pageSize);
            return Ok(visitorAccounts);
        }

    }
}