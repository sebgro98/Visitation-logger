using Microsoft.AspNetCore.Mvc;
using AuthenticationServer.DTO;
using AuthenticationServer.Services;

namespace AuthenticationServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public string Get()
        {

            return "LoginController test get";
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] LoginDto dto)
        {
            var token = await _authService.AuthenticateAsync(dto);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }


    }

}
