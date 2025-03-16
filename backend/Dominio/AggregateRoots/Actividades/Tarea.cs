

using Dominio.Common;
using Dominio.Entities;



namespace Dominio.AggregateRoots.Actividades
{
    public class Tarea : Entity
    {
        public string Descripcion { get; set; } = string.Empty;
        public bool Finalizado { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime? FechaHoraFinal { get; set; }

        // Relación con Actividad
        public int ActividadId { get; set; }
        public Actividad? Actividad { get; set; }
    }
}