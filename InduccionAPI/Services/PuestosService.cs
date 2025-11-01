using Dapper;
using InduccionAPI.Model.Puesto;
using System.Data;

namespace InduccionAPI.Services
{
    public class PuestosService : IPuestosService
    {
        private readonly IDbConnection _db;
        public PuestosService(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PuestoDto>> GetAllAsync()
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "R");

            var rows = await _db.QueryAsync<PuestoDto>(
                "SP_PUESTO_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );
            return rows;
        }

        public async Task<PuestoDto?> GetByIdAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "I");
            p.Add("@ID_PUESTO", id);

            var row = await _db.QueryFirstOrDefaultAsync<PuestoDto>(
                "SP_PUESTO_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );
            return row;
        }

        public async Task<(int status, object result)> CreateAsync(PuestoCreateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "C");
            p.Add("@ID_PUESTO", dbType: DbType.Int32, value: null);
            p.Add("@NOMBRE", dto.Nombre);
            p.Add("@DEPARTAMENTO_ID", dto.Departamento_Id);
            p.Add("@ACTIVO", dbType: DbType.Boolean, value: null);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_PUESTO_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );
            int code = (int)row.Codigo;
            return (code, row);
        }

        public async Task<(int status, object result)> UpdateAsync(PuestoUpdateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "U");
            p.Add("@ID_PUESTO", dto.Id);
            p.Add("@NOMBRE", dto.Nombre);
            p.Add("@DEPARTAMENTO_ID", dto.Departamento_Id);
            p.Add("@ACTIVO", dto.Activo);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_PUESTO_CRUD",
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
            p.Add("@ID_PUESTO", id);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_PUESTO_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );
            int code = (int)row.Codigo;
            return (code, row);
        }
    }
}
