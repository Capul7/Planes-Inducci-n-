using InduccionAPI.Model.Chatbot;
using InduccionAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InduccionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RetroalimentacionController : ControllerBase
    {
        private readonly IRetroalimentacionService _svc;
        public RetroalimentacionController(IRetroalimentacionService svc)
        {
            _svc = svc;
        }

        // POST /api/retroalimentacion
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Registrar([FromBody] RetroalimentacionCreateDto dto)
        {
            var (status, result) = await _svc.RegistrarAsync(dto);
            return StatusCode(status, result);
        }
    }
}
