using InduccionAPI.Model;
using InduccionAPI.Model.IndicadorAvance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InduccionAPI.Services
{
    public interface IIndicadorAvanceService
    {
        Task<(int status, object result)> CrearIndicadorAsync(IndicadorAvanceCreateDto dto);
        Task<IEnumerable<IndicadorAvanceDto>> HistorialAsync(int colaboradorId);
    }
}
