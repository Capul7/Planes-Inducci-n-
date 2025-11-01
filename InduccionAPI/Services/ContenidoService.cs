using Dapper;
using InduccionAPI.Model.Contenido;
using System.Data;

namespace InduccionAPI.Services
{
    public class ContenidoService : IContenidoService
    {
        private readonly IDbConnection _db;
        public ContenidoService(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ContenidoDto>> GetAllAsync()
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "R");

            var rows = await _db.QueryAsync<ContenidoDto>(
                "SP_CONTENIDO_INDUCCION_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            return rows;
        }

        public async Task<ContenidoDto?> GetByIdAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "I");
            p.Add("@ID_CONTENIDO", id);

            var row = await _db.QueryFirstOrDefaultAsync<ContenidoDto>(
                "SP_CONTENIDO_INDUCCION_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            return row;
        }

        public async Task<(int status, object result)> CreateAsync(ContenidoCreateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "C");
            p.Add("@ID_CONTENIDO", dbType: DbType.Int32, value: null);
            p.Add("@NOMBRE", dto.Nombre);
            p.Add("@TIPO_RECURSO", dto.Tipo_Recurso);
            p.Add("@DURACION_ESTIMADA", dto.Duracion_Estimada);
            p.Add("@URL_RECURSO", dto.Url_Recurso);
            p.Add("@ACTIVO", dbType: DbType.Boolean, value: null);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_CONTENIDO_INDUCCION_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            int code = (int)row.Codigo;
            return (code, row);
        }

        public async Task<(int status, object result)> UpdateAsync(ContenidoUpdateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "U");
            p.Add("@ID_CONTENIDO", dto.Id);
            p.Add("@NOMBRE", dto.Nombre);
            p.Add("@TIPO_RECURSO", dto.Tipo_Recurso);
            p.Add("@DURACION_ESTIMADA", dto.Duracion_Estimada);
            p.Add("@URL_RECURSO", dto.Url_Recurso);
            p.Add("@ACTIVO", dto.Activo);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_CONTENIDO_INDUCCION_CRUD",
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
            p.Add("@ID_CONTENIDO", id);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_CONTENIDO_INDUCCION_CRUD",
                p,
                commandType: CommandType.StoredProcedure
            );

            int code = (int)row.Codigo;
            return (code, row);
        }
    }
}
