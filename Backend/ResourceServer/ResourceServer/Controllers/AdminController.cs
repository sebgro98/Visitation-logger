﻿using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using AuthenticationServer.Model;
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
                FullName = dto.FullName,
                Password = dto.Password,
                AdminTypeId = dto.AdminTypeId
            };

            await _adminRepository.Insert(admin);
            await _adminRepository.SaveChangesAsync();

            return Ok(admin);
        }
    }
}
