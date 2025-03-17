using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Actividades
{
   public  class ActividadRequestDTO
    {
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaHoraInicio { get; set; }
        public bool Finalizado { get; set; }
        public DateTime? FechaFinalizado { get; set; }
        public int UsuarioId { get; set; }
        public int TipoId { get; set; }
        public List<TareaRequestDTO> Tareas { get; set; } = new();
    }
}
