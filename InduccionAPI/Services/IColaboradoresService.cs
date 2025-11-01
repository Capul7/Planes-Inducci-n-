using InduccionAPI.Models.Colaborador;

namespace InduccionAPI.Services
{
    public interface IColaboradoresService
    {
        Task<dynamic> CrearAsync(ColaboradorCreateDto dto);
        Task<IEnumerable<ColaboradorListDto>> ListarAsync();
        Task<ColaboradorDetalleDto?> ObtenerPorIdAsync(int id);
        Task<ColaboradorDetalleDto?> ObtenerPorUsuarioAsync(int idUsuario);
        Task<dynamic> ActualizarAsync(int id, ColaboradorUpdateDto dto);
        Task<dynamic> EliminarAsync(int id);
    }
}
