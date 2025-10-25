namespace InduccionAPI.Models.Colaborador
{
    public class ColaboradorDetalleDto
    {
        public int Id_Colaborador { get; set; }
        public string Nombre_Completo { get; set; } = "";
        public string Email { get; set; } = "";
        public string Dpi { get; set; } = "";
        public DateTime? Fecha_Ingreso { get; set; }
        public int Puesto_Id { get; set; }
        public string Puesto { get; set; } = "";
        public string Departamento { get; set; } = "";
        public bool Activo { get; set; }

        // solo para READ_BY_USER:
        public int? Id_Usuario { get; set; }
        public string? Username { get; set; }
        public int? Rol_Id { get; set; }
    }
}
