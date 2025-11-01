using System;

namespace InduccionAPI.Model.IndicadorAvance
{
    public class IndicadorAvanceCreateDto
    {
        public int Colaborador_Id { get; set; }
        public decimal Curva_Aprendizaje { get; set; }    // Ej: 80.5
        public decimal Autonomia { get; set; }            // Ej: 70.0
        public decimal Satisfaccion { get; set; }         // Ej: 90.0
    }

    public class IndicadorAvanceDto
    {
        public int Id { get; set; }
        public int Colaborador_Id { get; set; }
        public decimal Curva_Aprendizaje { get; set; }
        public decimal Autonomia { get; set; }
        public decimal Satisfaccion { get; set; }
        public DateTime Fecha_Registro { get; set; }
    }
}
