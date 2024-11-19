using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using SharedModels.Models;

namespace ResourceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PurposeTypeController : ControllerBase
    {
        private readonly IPurposeTypesRepository _purposeTypesRepository;

        public PurposeTypeController(IPurposeTypesRepository purposeTypesRepository)
        {
            _purposeTypesRepository = purposeTypesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurposeType>>> GetPurposeTypes()
        {
            var purposeTypes = await _purposeTypesRepository.GetPurposeTypes();

            return Ok(purposeTypes);
        }
    }
}
