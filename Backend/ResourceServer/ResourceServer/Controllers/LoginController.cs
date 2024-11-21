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
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
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
                var token = await response.Content.ReadAsStringAsync();

                // Forward the token to the client
                return Ok(new { token });
            }
            else
            {
                // Retrieve the status code and error message from the authentication server
                var statusCode = (int)response.StatusCode; // Forward the original status code
                var errorMessage = await response.Content.ReadAsStringAsync();

                // Return the error response with the correct status code and message
                return StatusCode(statusCode, new { Message = errorMessage });
            }
        }

    }
}
