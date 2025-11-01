using InduccionAPI.Model.Puesto;
using InduccionAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InduccionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuestosController : ControllerBase
    {
        private readonly IPuestosService _svc;
        public PuestosController(IPuestosService svc)
        {
            _svc = svc;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var data = await _svc.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _svc.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Create([FromBody] PuestoCreateDto dto)
        {
            var (status, result) = await _svc.CreateAsync(dto);
            return StatusCode(status, result);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Update([FromBody] PuestoUpdateDto dto)
        {
            var (status, result) = await _svc.UpdateAsync(dto);
            return StatusCode(status, result);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(int id)
        {
            var (status, result) = await _svc.DeleteAsync(id);
            return StatusCode(status, result);
        }
    }
}
