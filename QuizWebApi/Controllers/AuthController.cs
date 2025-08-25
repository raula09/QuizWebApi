using Microsoft.AspNetCore.Mvc;
using QuizWebApi.Services.Interfaces;

namespace QuizWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var token = await _auth.RegisterAsync(request);
            if (token == null) return BadRequest("User already exists");
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var token = await _auth.LoginAsync(request);
            if (token == null) return Unauthorized("Invalid credentials");
            return Ok(new { token });
        }
    }
}
