using InduccionAPI.Model.Planes;

namespace InduccionAPI.Services
{
    public interface IPlanesService
    {
        Task<IEnumerable<PlanInduccionDto>> GetAllAsync();
        Task<PlanInduccionDto?> GetByIdAsync(int id);
        Task<(int status, object result)> CreateAsync(PlanInduccionCreateDto dto);
        Task<(int status, object result)> UpdateAsync(PlanInduccionUpdateDto dto);
        Task<(int status, object result)> DeleteAsync(int id);
    }
}
