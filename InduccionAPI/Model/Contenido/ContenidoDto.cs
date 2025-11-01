using System;

namespace InduccionAPI.Model.Contenido
{
    public class ContenidoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Tipo_Recurso { get; set; } = "";
        public int Duracion_Estimada { get; set; }
        public string Url_Recurso { get; set; } = "";
        public bool Activo { get; set; }
    }

    public class ContenidoCreateDto
    {
        public string Nombre { get; set; } = "";
        public string Tipo_Recurso { get; set; } = "";
        public int Duracion_Estimada { get; set; }
        public string Url_Recurso { get; set; } = "";
    }

    public class ContenidoUpdateDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo_Recurso { get; set; }
        public int? Duracion_Estimada { get; set; }
        public string? Url_Recurso { get; set; }
        public bool? Activo { get; set; }
    }
}
