using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using SharedModels.Models;
using ResourceServer.DTO;
using System.Diagnostics;

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
