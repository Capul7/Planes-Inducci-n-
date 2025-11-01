using InduccionAPI.Model;
using InduccionAPI.Model.Rol;
using InduccionAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InduccionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _svc;
        public RolesController(IRolesService svc)
        {
            _svc = svc;
        }

        // GET /api/roles
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var data = await _svc.GetAllAsync();
            return Ok(data);
        }

        // GET /api/roles/5
        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _svc.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        // POST /api/roles
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Create([FromBody] RolCreateDto dto)
        {
            var (status, result) = await _svc.CreateAsync(dto);
            return StatusCode(status, result);
        }

        // PUT /api/roles
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Update([FromBody] RolUpdateDto dto)
        {
            var (status, result) = await _svc.UpdateAsync(dto);
            return StatusCode(status, result);
        }

        // DELETE /api/roles/5
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(int id)
        {
            var (status, result) = await _svc.DeleteAsync(id);
            return StatusCode(status, result);
        }
    }
}
