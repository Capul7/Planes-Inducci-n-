using System;

namespace InduccionAPI.Model.Chatbot
{
    public class ChatbotInteraccionCreateDto
    {
        public int Colaborador_Id { get; set; }
        public string Pregunta_Usuario { get; set; } = "";
        public string Respuesta_Generada { get; set; } = "";
        public int? Intencion_Id { get; set; }
    }

    public class ChatbotInteraccionDto
    {
        public int Id { get; set; }
        public int Colaborador_Id { get; set; }
        public string Colaborador_Nombre { get; set; } = "";
        public string Pregunta_Usuario { get; set; } = "";
        public string Respuesta_Generada { get; set; } = "";
        public DateTime Fecha_Hora { get; set; }
        public int? Intencion_Id { get; set; }
        public string Intencion_Nombre { get; set; } = "";
    }
}
