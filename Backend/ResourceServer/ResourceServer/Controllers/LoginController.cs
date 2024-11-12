using Microsoft.AspNetCore.Mvc;

namespace ResourceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        
        public LoginController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<ActionResult<object>> Login([FromBody] dynamic obj)
        {
            // Define the URL of the authentication server
            var authServerUrl = "https://localhost:[auth server port number]/login";

            // Send the POST request
            var response = await _httpClient.PostAsync(authServerUrl, obj);

            return Ok(obj);
        }
    }
}
