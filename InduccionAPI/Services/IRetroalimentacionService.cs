using InduccionAPI.Model.Chatbot;

namespace InduccionAPI.Services
{
    public interface IRetroalimentacionService
    {
        Task<(int status, object result)> RegistrarAsync(RetroalimentacionCreateDto dto);
    }
}
