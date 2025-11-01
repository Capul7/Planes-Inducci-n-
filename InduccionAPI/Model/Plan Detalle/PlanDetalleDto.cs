using System;

namespace InduccionAPI.Model.PlanDetalle
{
    public class PlanDetalleDto
    {
        public int Id { get; set; }
        public int Plan_Id { get; set; }
        public int Modulo_Id { get; set; }
        public string Modulo_Nombre { get; set; } = "";
        public int Orden { get; set; }
        public string Estado { get; set; } = "";
        public DateTime? Fecha_Completado { get; set; }
    }

    // Asignar módulo al plan
    public class PlanDetalleCreateDto
    {
        public int Plan_Id { get; set; }
        public int Modulo_Id { get; set; }
        public int Orden { get; set; }
    }

    // Actualizar estado u orden del módulo en el plan
    public class PlanDetalleUpdateDto
    {
        public int Id { get; set; }
        public string? Estado { get; set; }        // "Pendiente", "En Progreso", "Completado"
        public int? Orden { get; set; }
    }
}