using InduccionAPI.Model;
using InduccionAPI.Model.Usuario;
using InduccionAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InduccionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _svc;
        public UsuariosController(IUsuariosService svc)
        {
            _svc = svc;
        }

        // GET /api/usuarios
        [HttpGet]
        [Authorize(Roles = "ADMIN,RRHH")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _svc.GetAllAsync();
            return Ok(data);
        }

        // GET /api/usuarios/5
        [HttpGet("{id:int}")]
        [Authorize(Roles = "ADMIN,RRHH")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _svc.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        // POST /api/usuarios
        [HttpPost]
        [Authorize(Roles = "ADMIN,RRHH")]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateDto dto)
        {
            var (status, result) = await _svc.CreateAsync(dto);
            return StatusCode(status, result);
        }

        // PUT /api/usuarios
        [HttpPut]
        [Authorize(Roles = "ADMIN,RRHH")]
        public async Task<IActionResult> Update([FromBody] UsuarioUpdateDto dto)
        {
            var (status, result) = await _svc.UpdateAsync(dto);
            return StatusCode(status, result);
        }

        // DELETE /api/usuarios/5
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(int id)
        {
            var (status, result) = await _svc.DeleteAsync(id);
            return StatusCode(status, result);
        }
    }
}
