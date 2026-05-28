using APICrudTarefas.Application.DTO.Request;
using APICrudTarefas.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace APICrudTarefas.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {

            private readonly AuthService _authService;

            public AuthController(AuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("login")]
            public IActionResult Login([FromBody] LoginRequest request)
            {
                // simplificado (sem banco)
                if (request.Usuario != "admin" || request.Senha != "123")
                    return Unauthorized();

                var token = _authService.GerarToken(request.Usuario);

                return Ok(new { token });
            }
        }
}
