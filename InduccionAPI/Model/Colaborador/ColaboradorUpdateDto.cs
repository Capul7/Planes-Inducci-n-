namespace InduccionAPI.Models.Colaborador
{
    public class ColaboradorUpdateDto
    {
        public string? Nombre { get; set; }
        public string? Dpi { get; set; }
        public string? Email { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? PuestoId { get; set; }
        public bool? Activo { get; set; }
    }
}
