using Microsoft.AspNetCore.Mvc;
using TicketSystem.Models;
using TicketSystem.Services;

namespace TicketSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        // Ensure the key is a secure, 256-bit key
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Invalid registration request.");
            }

            // Implement registration logic here
            // E.g., save user credentials to a database

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Invalid login request.");
            }

            // Check credentials and generate a JWT token
            var token = _authService.GenerateToken(model.Username);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(new { Token = token });
        }
    }
}
