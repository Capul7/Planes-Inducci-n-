using System;

namespace InduccionAPI.Model.Usuario
{
    // Lo que el SP devuelve en opcion = 'R' y 'I'
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public int Rol_Id { get; set; }
        public string Rol_Nombre { get; set; } = "";
        public int? Colaborador_Id { get; set; }
        public string? Colaborador_Nombre { get; set; }
        public bool Activo { get; set; }
    }

    // Para crear
    public class UsuarioCreateDto
    {
        public string Nombre { get; set; } = "";        // username
        public string Pass { get; set; } = "";
        public int Rol_Id { get; set; }
        public int? Colaborador_Id { get; set; }
    }

    // Para actualizar
    public class UsuarioUpdateDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Pass { get; set; }
        public int? Rol_Id { get; set; }
        public int? Colaborador_Id { get; set; }
        public bool? Activo { get; set; }
    }
}
