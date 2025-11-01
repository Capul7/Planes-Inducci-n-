using InduccionAPI.Model.Chatbot;
using InduccionAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InduccionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatbotController : ControllerBase
    {
        private readonly IChatbotService _svc;
        public ChatbotController(IChatbotService svc)
        {
            _svc = svc;
        }

        // POST /api/chatbot/interaccion
        [HttpPost("interaccion")]
        [Authorize]
        public async Task<IActionResult> Registrar([FromBody] ChatbotInteraccionCreateDto dto)
        {
            var (status, result) = await _svc.RegistrarInteraccionAsync(dto);
            return StatusCode(status, result);
        }

        // GET /api/chatbot/historial/12
        [HttpGet("historial/{colaboradorId:int}")]
        [Authorize]
        public async Task<IActionResult> Historial(int colaboradorId)
        {
            var data = await _svc.HistorialPorColaboradorAsync(colaboradorId);
            return Ok(data);
        }
    }
}
