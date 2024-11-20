﻿using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using SharedModels.Models;
using ResourceServer.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;



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

        [Authorize(Roles = "MasterAdmin")]
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
        
        [Authorize(Roles = "MasterAdmin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAllAdmins()
        {
            var admins = await _adminRepository.GetAll();

            return Ok(admins);
        }
        
        [Authorize(Roles = "MasterAdmin")]
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

        [Authorize(Roles = "MasterAdmin")]
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


        [Authorize(Roles = "MasterAdmin")]
        [HttpGet("byPage")]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdminsByPage([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var admins = await _adminRepository.GetAdminsByPage(pageNumber, pageSize);
            return Ok(admins);
        }
    }
}
