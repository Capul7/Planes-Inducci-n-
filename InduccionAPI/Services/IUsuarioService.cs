using InduccionAPI.Model;
using InduccionAPI.Model.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InduccionAPI.Services
{
    public interface IUsuariosService
    {
        Task<IEnumerable<UsuarioDto>> GetAllAsync();
        Task<UsuarioDto?> GetByIdAsync(int id);
        Task<(int status, object result)> CreateAsync(UsuarioCreateDto dto);
        Task<(int status, object result)> UpdateAsync(UsuarioUpdateDto dto);
        Task<(int status, object result)> DeleteAsync(int id);
    }
}
