using Dapper;
using InduccionAPI.Model.PlanDetalle;
using System.Data;


namespace InduccionAPI.Services
{
    public class PlanDetalleService : IPlanDetalleService
    {
        private readonly IDbConnection _db;
        public PlanDetalleService(IDbConnection db)
        {
            _db = db;
        }

        // Listar módulos de un plan
        public async Task<IEnumerable<PlanDetalleDto>> GetByPlanAsync(int planId)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "L");
            p.Add("@PLAN_ID", planId);

            var rows = await _db.QueryAsync<PlanDetalleDto>(
                "SP_DETALLE_PLAN_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            return rows;
        }

        // Agregar módulo al plan
        public async Task<(int status, object result)> CreateAsync(PlanDetalleCreateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "C");
            p.Add("@ID_DETALLE", dbType: DbType.Int32, value: null);
            p.Add("@PLAN_ID", dto.Plan_Id);
            p.Add("@MODULO_ID", dto.Modulo_Id);
            p.Add("@ORDEN", dto.Orden);
            p.Add("@ESTADO", "Pendiente");
            p.Add("@FECHA_COMPLETADO", dbType: DbType.DateTime, value: null);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_DETALLE_PLAN_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );
            int code = (int)row.Codigo;
            return (code, row);
        }

        // Actualizar estado / orden
        public async Task<(int status, object result)> UpdateAsync(PlanDetalleUpdateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "U");
            p.Add("@ID_DETALLE", dto.Id);
            p.Add("@PLAN_ID", dbType: DbType.Int32, value: null);
            p.Add("@MODULO_ID", dbType: DbType.Int32, value: null);
            p.Add("@ORDEN", dto.Orden);
            p.Add("@ESTADO", dto.Estado);
            p.Add("@FECHA_COMPLETADO", dbType: DbType.DateTime, value: null);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_DETALLE_PLAN_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );
            int code = (int)row.Codigo;
            return (code, row);
        }

        // Eliminar del plan
        public async Task<(int status, object result)> DeleteAsync(int detalleId)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "D");
            p.Add("@ID_DETALLE", detalleId);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_DETALLE_PLAN_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );
            int code = (int)row.Codigo;
            return (code, row);
        }
    }
}
