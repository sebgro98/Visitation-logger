using Microsoft.AspNetCore.Mvc;
using ResourceServer.DTO;
using System.Text;
using System.Text.Json;

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
        public async Task<ActionResult<object>> Login([FromBody] LoginDTO dto)
        {
            // Define the URL of the authentication server
            var authServerUrl = "http://localhost:5247/login";

            // Serialize the DTO to JSON
            var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

            // Send the POST request
            var response = await _httpClient.PostAsync(authServerUrl, jsonContent);

            // Check if the response is successful
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            else
            {
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }
    }
}
