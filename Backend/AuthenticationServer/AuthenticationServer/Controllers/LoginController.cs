using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Get([FromBody] object obj)
        {
            string objString = obj.ToString();
            return Ok("LoginController test get " + objString);
        }
    }
}
