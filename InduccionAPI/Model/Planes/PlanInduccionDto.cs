using System;

namespace InduccionAPI.Model.Planes
{
    public class PlanInduccionDto
    {
        public int Id { get; set; }
        public int Colaborador_Id { get; set; }
        public string Colaborador_Nombre { get; set; } = "";
        public DateTime Fecha_Generacion { get; set; }
        public bool Activo { get; set; }
    }

    public class PlanInduccionCreateDto
    {
        public int Colaborador_Id { get; set; }
    }

    public class PlanInduccionUpdateDto
    {
        public int Id { get; set; }
        public int? Colaborador_Id { get; set; }
        public bool? Activo { get; set; }
    }
}
