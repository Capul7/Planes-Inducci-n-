namespace InduccionAPI.Models.Colaborador
{
    public class ColaboradorCreateDto
    {
        public string Nombre { get; set; } = "";
        public string Dpi { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime? FechaIngreso { get; set; }
        public int PuestoId { get; set; }
    }
}
