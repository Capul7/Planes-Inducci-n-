using Dapper;
using InduccionAPI.Model.Chatbot;
using System.Data;

namespace InduccionAPI.Services
{
    public class ChatbotService : IChatbotService
    {
        private readonly IDbConnection _db;
        public ChatbotService(IDbConnection db)
        {
            _db = db;
        }

        public async Task<(int status, object result)> RegistrarInteraccionAsync(ChatbotInteraccionCreateDto dto)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "C");
            p.Add("@ID_INTERACCION", dbType: DbType.Int32, value: null);
            p.Add("@COLABORADOR_ID", dto.Colaborador_Id);
            p.Add("@PREGUNTA_USUARIO", dto.Pregunta_Usuario);
            p.Add("@RESPUESTA_GENERADA", dto.Respuesta_Generada);
            p.Add("@INTENCION_ID", dto.Intencion_Id);

            var row = await _db.QueryFirstAsync<dynamic>(
                "SP_INTERACCION_CHATBOT",
                p,
                commandType: CommandType.StoredProcedure
            );

            // SP devuelve Mensaje, Codigo, id_interaccion
            int code = (int)row.Codigo;
            return (code, row);
        }

        public async Task<IEnumerable<ChatbotInteraccionDto>> HistorialPorColaboradorAsync(int colaboradorId)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", "L");
            p.Add("@COLABORADOR_ID", colaboradorId);

            var rows = await _db.QueryAsync<ChatbotInteraccionDto>(
                "SP_INTERACCION_CHATBOT",
                p,
                commandType: CommandType.StoredProcedure
            );

            return rows;
        }
    }
}
