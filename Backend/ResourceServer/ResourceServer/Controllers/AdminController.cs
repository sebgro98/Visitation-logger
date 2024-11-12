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
        public async Task<ActionResult<Admin>> PostAdmin([FromBody] AdminPostDTO dto)
        {

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
    }
}
