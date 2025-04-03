using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // ⚡ Aquí deberías validar con la base de datos (simplificado)
            if (request.Username == "admin" && request.Password == "1234")
            {
                var token = _jwtService.GenerateToken("1", "Admin");
                return Ok(new { Token = token });
            }

            return Unauthorized("Credenciales incorrectas.");
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
