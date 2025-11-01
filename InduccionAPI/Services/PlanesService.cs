using Dapper;
using InduccionAPI.Model.Planes;
using System.Data;

namespace InduccionAPI.Services
{
    public class PlanesService : IPlanesService
    {
        private readonly IDbConnection _db;
        public PlanesService(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PlanInduccionDto>> GetAllAsync()
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "R");

            var rows = await _db.QueryAsync<PlanInduccionDto>(
                "SP_PLAN_INDUCCION_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            return rows;
        }

        public async Task<PlanInduccionDto?> GetByIdAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "I");
            p.Add("@ID_PLAN", id);

            var row = await _db.QueryFirstOrDefaultAsync<PlanInduccionDto>(
                "SP_PLAN_INDUCCION_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            return row;
        }

        public async Task<(int status, object result)> CreateAsync(PlanInduccionCreateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "C");
            p.Add("@ID_PLAN", dbType: DbType.Int32, value: null);
            p.Add("@COLABORADOR_ID", dto.Colaborador_Id);
            p.Add("@ACTIVO", dbType: DbType.Boolean, value: null);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_PLAN_INDUCCION_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            int code = (int)row.Codigo;
            return (code, row);
        }

        public async Task<(int status, object result)> UpdateAsync(PlanInduccionUpdateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "U");
            p.Add("@ID_PLAN", dto.Id);
            p.Add("@COLABORADOR_ID", dto.Colaborador_Id);
            p.Add("@ACTIVO", dto.Activo);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_PLAN_INDUCCION_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            int code = (int)row.Codigo;
            return (code, row);
        }

        public async Task<(int status, object result)> DeleteAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "D");
            p.Add("@ID_PLAN", id);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_PLAN_INDUCCION_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            int code = (int)row.Codigo;
            return (code, row);
        }
    }
}
