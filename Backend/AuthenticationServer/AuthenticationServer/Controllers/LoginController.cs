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
                return Unauthorized("Lösenordet eller användarnamnet är felaktigt");
            }

            if (token == "Account has expired")
            {
                return Unauthorized("Kontot har löpt ut" );
            }

            if(token == "AccountLocked")
            {
                return Unauthorized("Kontot är låst. Försök igen senare");
            }

            return Ok(token);

        }


    }

}
