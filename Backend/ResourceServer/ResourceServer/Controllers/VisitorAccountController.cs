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
        public async Task<IActionResult> CreateVisitorAccount([FromBody] VisitorAccountDto dto)
        {
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


                return StatusCode(500, new { message = "An error occurred while creating the admin.", details = ex.Message });
            }
            
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


                return StatusCode(500, new { message = "An error occurred while creating the visitor account.", details = ex.Message });
            }


        }

        [HttpGet("byPage")]
        public async Task<ActionResult<ByPageVisitorAccountDTO>> GetAdminsByPage([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var visitorAccounts = await _visitorAccountRepository.GetVisitorAccountByPage(pageNumber, pageSize);
            return Ok(visitorAccounts);
        }

    }
}