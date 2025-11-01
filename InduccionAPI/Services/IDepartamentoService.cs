using InduccionAPI.Model.Departamento;

namespace InduccionAPI.Services
{
    public interface IDepartamentosService
    {
        Task<IEnumerable<DepartamentoDto>> GetAllAsync();
        Task<DepartamentoDto?> GetByIdAsync(int id);
        Task<(int status, object result)> CreateAsync(DepartamentoCreateDto dto);
        Task<(int status, object result)> UpdateAsync(DepartamentoUpdateDto dto);
        Task<(int status, object result)> DeleteAsync(int id);
    }
}
