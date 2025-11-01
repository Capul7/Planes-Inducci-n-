using InduccionAPI.Model;
using InduccionAPI.Model.Contenido;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InduccionAPI.Services
{
    public interface IContenidoService
    {
        Task<IEnumerable<ContenidoDto>> GetAllAsync();
        Task<ContenidoDto?> GetByIdAsync(int id);
        Task<(int status, object result)> CreateAsync(ContenidoCreateDto dto);
        Task<(int status, object result)> UpdateAsync(ContenidoUpdateDto dto);
        Task<(int status, object result)> DeleteAsync(int id);
    }
}
