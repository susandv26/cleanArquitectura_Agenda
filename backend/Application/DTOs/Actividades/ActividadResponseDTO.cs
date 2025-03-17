using Application.DTOs.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Actividades;
using Application.DTOs.Entidades;

namespace Application.DTOs.Actividades
{
    public class ActividadResponseDTO
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
<<<<<<< HEAD:backend/Application/DTOs/Actividades/ActividadRespondeDTO.cs
        public TipoResponseDTO? Tipo { get; set; }
=======
        
>>>>>>> b37f5404f2203ef03b8d08e75ff0e61ced130ff6:backend/Application/DTOs/Actividades/ActividadResponseDTO.cs
    }
}
