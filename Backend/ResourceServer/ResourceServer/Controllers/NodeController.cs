using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using SharedModels.Models;

namespace ResourceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly INodeRepository _nodeRepository;

        public NodeController(INodeRepository nodeRepository) 
        { 
            _nodeRepository = nodeRepository;
        
        }
        [Authorize(Roles = "MasterAdmin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Node>>> GetAllAdmins()
        {
            var admins = await _nodeRepository.GetAllNodes();

            return Ok(admins);
        }
    }
}
