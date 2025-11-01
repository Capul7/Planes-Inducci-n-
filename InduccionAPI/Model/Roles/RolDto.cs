using System;

namespace InduccionAPI.Model.Rol
{
    public class RolDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public bool Activo { get; set; }
    }

    public class RolCreateDto
    {
        public string Nombre { get; set; } = "";
    }

    public class RolUpdateDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public bool? Activo { get; set; }
    }
}
