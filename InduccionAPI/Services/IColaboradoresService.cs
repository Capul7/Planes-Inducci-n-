using System.Data;
using Dapper;
using InduccionAPI.Models.Colaborador;

namespace InduccionAPI.Services
{
    public interface IColaboradoresService
    {
        Task<dynamic> CrearAsync(ColaboradorCreateDto dto);
        Task<IEnumerable<ColaboradorListDto>> ListarAsync();
        Task<ColaboradorDetalleDto?> ObtenerPorIdAsync(int id);
        Task<ColaboradorDetalleDto?> ObtenerPorUsuarioAsync(int idUsuario);
        Task<dynamic> ActualizarAsync(int id, ColaboradorUpdateDto dto);
        Task<dynamic> EliminarAsync(int id);
    }

    public class ColaboradoresService : IColaboradoresService
    {
        private readonly IDbConnection _db;

        public ColaboradoresService(IDbConnection db)
        {
            _db = db;
        }

        public async Task<dynamic> CrearAsync(ColaboradorCreateDto dto)
        {
            var result = await _db.QueryFirstOrDefaultAsync<dynamic>(
                "SP_COLABORADOR_CRUD",
                new
                {
                    opcion = "C",
                    NOMBRE = dto.Nombre,
                    DPI = dto.Dpi,
                    EMAIL = dto.Email,
                    FECHA_INGRESO = dto.FechaIngreso,
                    PUESTO_ID = dto.PuestoId
                },
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<IEnumerable<ColaboradorListDto>> ListarAsync()
        {
            var result = await _db.QueryAsync<ColaboradorListDto>(
                "SP_COLABORADOR_CRUD",
                new { opcion = "R" },
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<ColaboradorDetalleDto?> ObtenerPorIdAsync(int id)
        {
            var result = await _db.QueryFirstOrDefaultAsync<ColaboradorDetalleDto>(
                "SP_COLABORADOR_CRUD",
                new
                {
                    opcion = "I",
                    ID_COLABORADOR = id
                },
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<ColaboradorDetalleDto?> ObtenerPorUsuarioAsync(int idUsuario)
        {
            var result = await _db.QueryFirstOrDefaultAsync<ColaboradorDetalleDto>(
                "SP_COLABORADOR_CRUD",
                new
                {
                    opcion = "X",
                    ID_USUARIO = idUsuario
                },
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<dynamic> ActualizarAsync(int id, ColaboradorUpdateDto dto)
        {
            var result = await _db.QueryFirstOrDefaultAsync<dynamic>(
                "SP_COLABORADOR_CRUD",
                new
                {
                    opcion = "U",
                    ID_COLABORADOR = id,
                    NOMBRE = dto.Nombre,
                    DPI = dto.Dpi,
                    EMAIL = dto.Email,
                    FECHA_INGRESO = dto.FechaIngreso,
                    PUESTO_ID = dto.PuestoId,
                    ACTIVO = dto.Activo
                },
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<dynamic> EliminarAsync(int id)
        {
            var result = await _db.QueryFirstOrDefaultAsync<dynamic>(
                "SP_COLABORADOR_CRUD",
                new
                {
                    opcion = "D",
                    ID_COLABORADOR = id
                },
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}
