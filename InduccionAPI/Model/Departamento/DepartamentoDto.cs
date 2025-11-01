using System;

namespace InduccionAPI.Model.Departamento
{
    public class DepartamentoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public bool Activo { get; set; }
    }

    public class DepartamentoCreateDto
    {
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
    }

    public class DepartamentoUpdateDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }
    }
}
