using InduccionAPI.Model.PlanDetalle;
using InduccionAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InduccionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanDetalleController : ControllerBase
    {
        private readonly IPlanDetalleService _svc;
        public PlanDetalleController(IPlanDetalleService svc)
        {
            _svc = svc;
        }

        // GET /api/planDetalle/plan/7
        [HttpGet("plan/{planId:int}")]
        [Authorize]
        public async Task<IActionResult> GetByPlan(int planId)
        {
            var data = await _svc.GetByPlanAsync(planId);
            return Ok(data);
        }

        // POST /api/planDetalle
        [HttpPost]
        [Authorize(Roles = "ADMIN,SUPERVISOR, RRHH")]
        public async Task<IActionResult> Create([FromBody] PlanDetalleCreateDto dto)
        {
            var (status, result) = await _svc.CreateAsync(dto);
            return StatusCode(status, result);
        }

        // PATCH /api/planDetalle
        [HttpPatch]
        [Authorize(Roles = "ADMIN,SUPERVISOR, RRHH")]
        public async Task<IActionResult> Update([FromBody] PlanDetalleUpdateDto dto)
        {
            var (status, result) = await _svc.UpdateAsync(dto);
            return StatusCode(status, result);
        }

        // DELETE /api/planDetalle/15
        [HttpDelete("{detalleId:int}")]
        [Authorize(Roles = "ADMIN,SUPERVISOR, RRHH")]
        public async Task<IActionResult> Delete(int detalleId)
        {
            var (status, result) = await _svc.DeleteAsync(detalleId);
            return StatusCode(status, result);
        }
    }
}
