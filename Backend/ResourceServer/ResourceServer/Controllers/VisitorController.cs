using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using SharedModels.Models;
using ResourceServer.DTO;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace ResourceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IVisitorAccountRepository _visitorAccountRepository;

        public VisitorController(IVisitorRepository visitorRepository, IVisitorAccountRepository visitorAccountRepository)
        {
            _visitorAccountRepository = visitorAccountRepository;
            _visitorRepository = visitorRepository;
        }

    [Authorize(Roles = "MasterAdmin, Visitor")]
    [HttpPost]
    public async Task<ActionResult<Visitor>> CreateVisitor([FromBody] VisitorDTO dto)
    {

        var createdVisitor = await _visitorRepository.CreateVisitor(dto);

        if (createdVisitor == null)
        {
            return BadRequest("Country not found");
        }

        var visitorAccount = await _visitorAccountRepository.GetVisitorAccountById(dto.VisitorAccountId);

        if (visitorAccount == null)
        {
            return NotFound();
        }

        var updatedVisitorAccountDto = new VisitorAccountDto
        {
            AccountTypeId = visitorAccount.AccountTypeId,
             PurposeTypeId = visitorAccount.PurposeTypeId,
            StartDate = visitorAccount.StartDate,
            EndDate = visitorAccount.EndDate,
            UserName = visitorAccount.Username,
            Password = visitorAccount.Password,
            VisitorId = createdVisitor.Id,
            NodeId = visitorAccount.NodeId
        };

   
        await _visitorAccountRepository.UpdateVisitorAccount(visitorAccount.Id, updatedVisitorAccountDto);


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
        public async Task<ActionResult<Visitor>> UpdateVisitor(Guid id, [FromBody] VisitorPutDTO visitorPutDTO)
        {
            Debug.WriteLine("test visitorController terminal output");
            var visitorToUpdate = await _visitorRepository.UpdateVisitor(id, visitorPutDTO);

            if(visitorToUpdate == null)
            {
                return NotFound();
            }

            return Ok(visitorPutDTO);
        }
    }
}
