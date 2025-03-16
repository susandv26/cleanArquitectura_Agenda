using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Actividades
{
    class TareaResponseDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Finalizado { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime? FechaHoraFinal { get; set; }
        public int ActividadId { get; set; }
    }
}
