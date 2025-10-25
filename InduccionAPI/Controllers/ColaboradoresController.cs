using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using InduccionAPI.Services;
using InduccionAPI.Models.Colaborador;

namespace InduccionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN")] // Sólo admin maneja colaboradores
    public class ColaboradoresController : ControllerBase
    {
        private readonly IColaboradoresService _svc;

        public ColaboradoresController(IColaboradoresService svc)
        {
            _svc = svc;
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ColaboradorCreateDto dto)
        {
            var result = await _svc.CrearAsync(dto);
            return Ok(result); // {Mensaje, Codigo, id_colaborador}
        }

        // READ_ALL
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var data = await _svc.ListarAsync();
            return Ok(data);
        }

        // READ_ONE
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var data = await _svc.ObtenerPorIdAsync(id);
            if (data == null)
                return NotFound(new { Mensaje = "No existe el colaborador", Codigo = 404 });
            return Ok(data);
        }

        // READ_BY_USER
        [HttpGet("usuario/{idUsuario:int}")]
        public async Task<IActionResult> ObtenerPorUsuario(int idUsuario)
        {
            var data = await _svc.ObtenerPorUsuarioAsync(idUsuario);
            if (data == null)
                return NotFound(new { Mensaje = "No existe el usuario asociado", Codigo = 404 });
            return Ok(data);
        }

        // UPDATE
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ColaboradorUpdateDto dto)
        {
            var result = await _svc.ActualizarAsync(id, dto);
            return Ok(result); // {Mensaje, Codigo, id_colaborador}
        }

        // DELETE LÓGICO
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _svc.EliminarAsync(id);
            return Ok(result); // {Mensaje, Codigo, id_colaborador}
        }
    }
}
