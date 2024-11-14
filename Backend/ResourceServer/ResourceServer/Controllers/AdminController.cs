using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using SharedModels.Models;
using ResourceServer.DTO;

namespace ResourceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin([FromBody] AdminDTO dto)
        {
            //Add validation of required fields (required not present in AdminDTO) to avoid null values

            var admin = new Admin
            {
                Id = Guid.NewGuid(),
                Username = dto.Username,
                Password = dto.Password,
                AccountTypeId = dto.AccountTypeId
            };

            await _adminRepository.Insert(admin);
            await _adminRepository.SaveChangesAsync();

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
            var adminToUpdate = await _adminRepository.GetById(id);

            if (adminToUpdate == null)
            {
                return NotFound();
            }

            var updatedAdmin = await _adminRepository.Update(id, dto);

            return Ok(updatedAdmin);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdmin(Guid id)
        {
            var adminToDelete = await _adminRepository.GetById(id);

            if(adminToDelete == null)
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
    }
}
