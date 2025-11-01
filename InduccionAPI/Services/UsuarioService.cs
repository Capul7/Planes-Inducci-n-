using Dapper;
using InduccionAPI.Model.Usuario;
using System.Data;

namespace InduccionAPI.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IDbConnection _db;
        public UsuariosService(IDbConnection db)
        {
            _db = db;
        }

        // GET all
        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "R");

            var rows = await _db.QueryAsync<UsuarioDto>(
                "SP_USUARIO_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            return rows;
        }

        // GET by id
        public async Task<UsuarioDto?> GetByIdAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "I");
            p.Add("@ID_USUARIO", id);

            // tu SP en opcion 'I' devuelve también pass, pero acá mapeamos al dto sin pass
            var row = await _db.QueryFirstOrDefaultAsync<UsuarioDto>(
                "SP_USUARIO_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            return row;
        }

        // POST - create
        public async Task<(int status, object result)> CreateAsync(UsuarioCreateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "C");
            p.Add("@ID_USUARIO", dbType: DbType.Int32, value: null);
            p.Add("@NOMBRE", dto.Nombre);
            p.Add("@PASS", dto.Pass);
            p.Add("@ROL_ID", dto.Rol_Id);
            p.Add("@COLABORADOR_ID", dto.Colaborador_Id);
            p.Add("@ACTIVO", dbType: DbType.Boolean, value: null);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_USUARIO_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            int code = (int)row.Codigo;
            return (code, row);
        }

        // PUT - update
        public async Task<(int status, object result)> UpdateAsync(UsuarioUpdateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "U");
            p.Add("@ID_USUARIO", dto.Id);
            p.Add("@NOMBRE", dto.Nombre);
            p.Add("@PASS", dto.Pass);
            p.Add("@ROL_ID", dto.Rol_Id);
            p.Add("@COLABORADOR_ID", dto.Colaborador_Id);
            p.Add("@ACTIVO", dto.Activo);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_USUARIO_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            int code = (int)row.Codigo;
            return (code, row);
        }

        // DELETE lógico
        public async Task<(int status, object result)> DeleteAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "D");
            p.Add("@ID_USUARIO", id);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_USUARIO_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            int code = (int)row.Codigo;
            return (code, row);
        }
    }
}
