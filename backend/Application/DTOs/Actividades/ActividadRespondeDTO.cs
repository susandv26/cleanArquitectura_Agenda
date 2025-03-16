using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Actividades
{
    class ActividadRespondeDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaHoraInicio { get; set; }
        public bool Finalizado { get; set; }
        public DateTime? FechaFinalizado { get; set; }
        public int UsuarioId { get; set; }
        public int TipoId { get; set; }
        public List<TareaResponseDTO> Tareas { get; set; } = new();
        public UsuarioResponseDTO? Usuario { get; set; }
        public CatalogResponseDTO? Tipo { get; set; }
    }
}
