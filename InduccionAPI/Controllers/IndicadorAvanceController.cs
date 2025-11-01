using InduccionAPI.Model.IndicadorAvance;
using InduccionAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InduccionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndicadorAvanceController : ControllerBase
    {
        private readonly IIndicadorAvanceService _svc;
        public IndicadorAvanceController(IIndicadorAvanceService svc)
        {
            _svc = svc;
        }

        // POST /api/indicadorAvance
        [HttpPost]
        [Authorize(Roles = "ADMIN,SUPERVISOR,RRHH")]
        public async Task<IActionResult> Crear([FromBody] IndicadorAvanceCreateDto dto)
        {
            var (status, result) = await _svc.CrearIndicadorAsync(dto);
            return StatusCode(status, result);
        }

        // GET /api/indicadorAvance/historial/12
        [HttpGet("historial/{colaboradorId:int}")]
        [Authorize(Roles = "ADMIN,SUPERVISOR,RRHH")]
        public async Task<IActionResult> Historial(int colaboradorId)
        {
            var data = await _svc.HistorialAsync(colaboradorId);
            return Ok(data);
        }
    }
}
