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

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] LoginDto dto)
        {
            var token = await _authService.AuthenticateAsync(dto);
            if (token == "Invalid credentials")
            {
                return Unauthorized("Password or Username incorrect" );
            }

            if (token == "Account has expired")
            {
                return Unauthorized("Account has expired" );
            }

            if(token == "AccountLocked")
            {
                return Unauthorized("Account is locked. Please try again later");
            }

            return Ok(token);

        }


    }

}
