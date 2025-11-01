using Dapper;
using InduccionAPI.Model.Departamento;
using System.Data;

namespace InduccionAPI.Services
{
    public class DepartamentosService : IDepartamentosService
    {
        private readonly IDbConnection _db;
        public DepartamentosService(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<DepartamentoDto>> GetAllAsync()
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "R");

            var rows = await _db.QueryAsync<DepartamentoDto>(
                "SP_DEPARTAMENTO_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );
            return rows;
        }

        public async Task<DepartamentoDto?> GetByIdAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "I");
            p.Add("@ID_DEPARTAMENTO", id);

            var row = await _db.QueryFirstOrDefaultAsync<DepartamentoDto>(
                "SP_DEPARTAMENTO_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );
            return row;
        }

        public async Task<(int status, object result)> CreateAsync(DepartamentoCreateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "C");
            p.Add("@ID_DEPARTAMENTO", dbType: DbType.Int32, value: null);
            p.Add("@NOMBRE", dto.Nombre);
            p.Add("@DESCRIPCION", dto.Descripcion);
            p.Add("@ACTIVO", dbType: DbType.Boolean, value: null);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_DEPARTAMENTO_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );
            int code = (int)row.Codigo;
            return (code, row);
        }

        public async Task<(int status, object result)> UpdateAsync(DepartamentoUpdateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "U");
            p.Add("@ID_DEPARTAMENTO", dto.Id);
            p.Add("@NOMBRE", dto.Nombre);
            p.Add("@DESCRIPCION", dto.Descripcion);
            p.Add("@ACTIVO", dto.Activo);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_DEPARTAMENTO_CRUD",
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
            p.Add("@ID_DEPARTAMENTO", id);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_DEPARTAMENTO_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );
            int code = (int)row.Codigo;
            return (code, row);
        }
    }
}
