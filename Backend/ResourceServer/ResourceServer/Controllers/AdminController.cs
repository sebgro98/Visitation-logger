using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using SharedModels.Models;
using ResourceServer.DTO;
<<<<<<< HEAD
<<<<<<< HEAD
using System.Text.RegularExpressions;
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> 0200bf13569543be7b7d2c5d2a50ec6801c81c47
=======
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
>>>>>>> 3fce37e87dcd80e95ed52cc08b8c09bd145c229b

namespace ResourceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private static readonly Regex usernameRegex = new Regex("^[a-zA-Z0-9.@]{4,50}$");

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin([FromBody] AdminDTO dto)
        {
            ActionResult adminValidationResult = ValidateAdminData(dto);
            if(adminValidationResult is BadRequestObjectResult)
            {
                return adminValidationResult;
            }

            var admin = await _adminRepository.Create(dto);

            return Ok(admin);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdminById(Guid id)
        {
            var admin = await _adminRepository.GetById(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAllAdmins()
        {
            var admins = await _adminRepository.GetAll();

            return Ok(admins);
        }

        [HttpPut("{id}")] //The ID of the admin to be updated
        public async Task<ActionResult<Admin>> UpdateAdmin(Guid id, AdminDTO dto)
        {
            ActionResult adminValidationResult = ValidateAdminData(dto);
            if (adminValidationResult is BadRequestObjectResult)
            {
                return adminValidationResult;
            }

            var admin = await _adminRepository.Update(id, dto);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdmin(Guid id)
        {
            var admin = await _adminRepository.GetById(id);

            if(admin == null)
            {
                return NotFound();
            }

            var successfulDelete = await _adminRepository.Delete(id);

            if(!successfulDelete)
            {
                return BadRequest();
            }

            return Ok();
        }

        private ActionResult ValidateAdminData(AdminDTO adminDto)
        {
            if (!usernameRegex.IsMatch(adminDto.Username))
            {
                return BadRequest("Username must be at least 4 and at most 50 characters, and can only contain letters, numbers, periods and at signs.");
            }
            if (!adminDto.FullName.All(char.IsLetter)){
                return BadRequest("Full name can only contain letters.");
            }
            return Ok();
        }

        [HttpGet("byPage")]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdminsByPage([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var admins = await _adminRepository.GetAdminsByPage(pageNumber, pageSize);
            return Ok(admins);
        }
    }
}
