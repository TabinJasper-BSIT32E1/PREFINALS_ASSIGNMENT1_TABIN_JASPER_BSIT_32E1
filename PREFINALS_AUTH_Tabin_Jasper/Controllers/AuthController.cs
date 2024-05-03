using AuthServer.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            // Validate credentials
            if (!await _userService.ValidateCredentialsAsync(model.Username, model.Password))
            {
                return Unauthorized("Invalid username or password");
            }

            // Generate JWT token
            var token = await _authService.GenerateJwtTokenAsync(model.Username);

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            // Implement user registration logic here
            // Example: Create a new user with provided details

            return Ok("Registration successful");
        }

        // Add other endpoints for user management (e.g., password change, locking) as needed
    }

    public class LoginRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterRequestModel
    {
        // Add properties for user registration (e.g., username, password, email) as needed
    }
}
