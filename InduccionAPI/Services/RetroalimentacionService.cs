using Dapper;
using InduccionAPI.Model.Chatbot;
using System.Data;

namespace InduccionAPI.Services
{
    public class RetroalimentacionService : IRetroalimentacionService
    {
        private readonly IDbConnection _db;
        public RetroalimentacionService(IDbConnection db)
        {
            _db = db;
        }

        public async Task<(int status, object result)> RegistrarAsync(RetroalimentacionCreateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@INTERACCION_ID", dto.Interaccion_Id);
            p.Add("@ES_UTIL", dto.Es_Util);
            p.Add("@COMENTARIOS", dto.Comentarios);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_RETROALIMENTACION",
                p,
                commandType: CommandType.StoredProcedure
            );

            // SP_RETROALIMENTACION devuelve Mensaje, Codigo
            int code = (int)row.Codigo;
            return (code, row);
        }
    }
}
