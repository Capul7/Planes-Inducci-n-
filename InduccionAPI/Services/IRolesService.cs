using InduccionAPI.Model;
using InduccionAPI.Model.Rol;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InduccionAPI.Services
{
    public interface IRolesService
    {
        Task<IEnumerable<RolDto>> GetAllAsync();
        Task<RolDto?> GetByIdAsync(int id);
        Task<(int status, object result)> CreateAsync(RolCreateDto dto);
        Task<(int status, object result)> UpdateAsync(RolUpdateDto dto);
        Task<(int status, object result)> DeleteAsync(int id);
    }
}
