using Microsoft.AspNetCore.Mvc;
using ResourceServer.Repositories;
using SharedModels.Models;

namespace ResourceServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeRepository _accountTypesRepository;

        public AccountTypeController(IAccountTypeRepository accountTypesRepository)
        {
            _accountTypesRepository = accountTypesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountType>>> GetAllAccountTypes()
        {
            var admins = await _accountTypesRepository.GetAll();

            return Ok(admins);
        }
    }
}
