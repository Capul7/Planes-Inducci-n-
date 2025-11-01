using Dapper;
using InduccionAPI.Model.Rol;
using System.Data;

namespace InduccionAPI.Services
{
    public class RolesService : IRolesService
    {
        private readonly IDbConnection _db;
        public RolesService(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<RolDto>> GetAllAsync()
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "R");

            var rows = await _db.QueryAsync<RolDto>(
                "SP_ROL_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            return rows;
        }

        public async Task<RolDto?> GetByIdAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "I");
            p.Add("@ID_ROL", id);

            var row = await _db.QueryFirstOrDefaultAsync<RolDto>(
                "SP_ROL_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            return row;
        }

        public async Task<(int status, object result)> CreateAsync(RolCreateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "C");
            p.Add("@ID_ROL", dbType: DbType.Int32, value: null);
            p.Add("@NOMBRE", dto.Nombre);
            p.Add("@ACTIVO", dbType: DbType.Boolean, value: null);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_ROL_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            int code = (int)row.Codigo;
            return (code, row);
        }

        public async Task<(int status, object result)> UpdateAsync(RolUpdateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "U");
            p.Add("@ID_ROL", dto.Id);
            p.Add("@NOMBRE", dto.Nombre);
            p.Add("@ACTIVO", dto.Activo);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_ROL_CRUD",
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
            p.Add("@ID_ROL", id);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_ROL_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            int code = (int)row.Codigo;
            return (code, row);
        }
    }
}
