using Dapper;
using InduccionAPI.Model.IndicadorAvance;
using System.Data;

namespace InduccionAPI.Services
{
    public class IndicadorAvanceService : IIndicadorAvanceService
    {
        private readonly IDbConnection _db;
        public IndicadorAvanceService(IDbConnection db)
        {
            _db = db;
        }

        public async Task<(int status, object result)> CrearIndicadorAsync(IndicadorAvanceCreateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "C");
            p.Add("@ID_INDICADOR", dbType: DbType.Int32, value: null);
            p.Add("@COLABORADOR_ID", dto.Colaborador_Id);
            p.Add("@CURVA_APRENDIZAJE", dto.Curva_Aprendizaje);
            p.Add("@AUTONOMIA", dto.Autonomia);
            p.Add("@SATISFACCION", dto.Satisfaccion);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_INDICADOR_AVANCE",
                p,
                commandType: CommandType.StoredProcedure
            );

            // SP devuelve Mensaje, Codigo, id_indicador
            int code = (int)row.Codigo;
            return (code, row);
        }

        public async Task<IEnumerable<IndicadorAvanceDto>> HistorialAsync(int colaboradorId)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "L");
            p.Add("@COLABORADOR_ID", colaboradorId);

            var rows = await _db.QueryAsync<IndicadorAvanceDto>(
                "SP_INDICADOR_AVANCE",
                p,
                commandType: CommandType.StoredProcedure
            );

            return rows;
        }
    }
}
