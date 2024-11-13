using Microsoft.AspNetCore.Mvc;
using AuthenticationServer.DTO;

namespace AuthenticationServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {

        }

        [HttpGet]
        public string Get()
        {
            return "LoginController test get";
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] LoginDTO dto)
        {
            return Ok(dto);
        }
    }
}
