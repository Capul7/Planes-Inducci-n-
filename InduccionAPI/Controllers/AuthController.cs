using Api.Auth.Models;
using Api.Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;

    public AuthController(IAuthService auth) => _auth = auth;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var res = await _auth.LoginAsync(request);
        if (res is null) return Unauthorized(new { message = "Credenciales inválidas" });
        return Ok(res);
    }

    [HttpGet("me")]
    public IActionResult Me()
    {
        if (!User.Identity?.IsAuthenticated ?? true) return Unauthorized();
        return Ok(new
        {
            sub = User.FindFirst("usuario_id")?.Value,
            usuario = User.Identity!.Name,
            rol = User.FindFirst("role")?.Value ?? User.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value,
            nombre_colaborador = User.FindFirst("nombre_colaborador")?.Value
        });
    }
}
