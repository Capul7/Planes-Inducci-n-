using InduccionAPI.Model.Puesto;

namespace InduccionAPI.Services
{
    public interface IPuestosService
    {
        Task<IEnumerable<PuestoDto>> GetAllAsync();
        Task<PuestoDto?> GetByIdAsync(int id);
        Task<(int status, object result)> CreateAsync(PuestoCreateDto dto);
        Task<(int status, object result)> UpdateAsync(PuestoUpdateDto dto);
        Task<(int status, object result)> DeleteAsync(int id);
    }
}
