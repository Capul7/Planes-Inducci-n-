using InduccionAPI.Model.PlanDetalle;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InduccionAPI.Services
{
    public interface IPlanDetalleService
    {
        Task<IEnumerable<PlanDetalleDto>> GetByPlanAsync(int planId);
        Task<(int status, object result)> CreateAsync(PlanDetalleCreateDto dto);
        Task<(int status, object result)> UpdateAsync(PlanDetalleUpdateDto dto);
        Task<(int status, object result)> DeleteAsync(int detalleId);
    }
}
