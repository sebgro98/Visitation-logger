using AuthenticationServer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceServer.Repository;

namespace ResourceServer.Controller
{
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IVisitorAccountRepository _visitorAccountRepository;


        public UsersController(VisitorAccountRepository visitorAccountuserRepository)
        {
            _visitorAccountRepository = visitorAccountuserRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisitorAccount([FromBody] VisitorAccount visitorAccount)
        {
            await _visitorAccountRepository.CreateVisitorAccount(visitorAccount);
            return Ok(visitorAccount);
        }

    }
}