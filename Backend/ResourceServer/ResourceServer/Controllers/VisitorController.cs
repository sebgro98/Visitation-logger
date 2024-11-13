using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using SharedModels.Models;
using ResourceServer.DTO;

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

        [HttpPost]
        public async Task<ActionResult<Visitor>> CreateVisitor([FromBody] VisitorDTO dto)
        {

            var createdVisitor = await _visitorRepository.CreateVisitor(dto);
            var visitorAccount = await _visitorAccountRepository.GetVisitorAccountById(dto.VisitorAccountId);

            if (visitorAccount == null)
            {
                return NotFound();
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
    }
}
