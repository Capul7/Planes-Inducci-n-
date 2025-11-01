using InduccionAPI.Model.Chatbot;

namespace InduccionAPI.Services
{
    public interface IChatbotService
    {
        Task<(int status, object result)> RegistrarInteraccionAsync(ChatbotInteraccionCreateDto dto);
        Task<IEnumerable<ChatbotInteraccionDto>> HistorialPorColaboradorAsync(int colaboradorId);
    }
}
