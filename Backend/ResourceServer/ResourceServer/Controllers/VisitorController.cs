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

        public VisitorController(IVisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Visitor>> CreateVisitor([FromBody] VisitorDTO dto)
        {
            var createdVisitor = await _visitorRepository.CreateVisitor(dto);

            return Ok(createdVisitor);
        }
    }
}