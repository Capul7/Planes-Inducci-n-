namespace InduccionAPI.Model.Chatbot
{
    public class RetroalimentacionCreateDto
    {
        public int Interaccion_Id { get; set; }
        public bool? Es_Util { get; set; }
        public string? Comentarios { get; set; }
    }
}
