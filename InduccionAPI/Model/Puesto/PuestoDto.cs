using System;

namespace InduccionAPI.Model.Puesto
{
    public class PuestoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public int Departamento_Id { get; set; }
        public string Departamento { get; set; } = "";
        public bool Activo { get; set; }
    }

    public class PuestoCreateDto
    {
        public string Nombre { get; set; } = "";
        public int Departamento_Id { get; set; }
    }

    public class PuestoUpdateDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? Departamento_Id { get; set; }
        public bool? Activo { get; set; }
    }
}
