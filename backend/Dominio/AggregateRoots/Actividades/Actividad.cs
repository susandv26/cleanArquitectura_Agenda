using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Common;

namespace Dominio.AggregateRoots.Actividades
{
    public class Actividad : AggregateRoot
    {
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaHoraInicio { get; set; }
        public bool Finalizado { get; set; }
        public DateTime? FechaFinalizado { get; set; }

        // Relación con Usuario
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        // Relación con Tipo
        public int TipoId { get; set; }
        public Tipo? Tipo { get; set; }

        // Colección de Tareas asociadas
        public List<Tarea> Tareas { get; set; } = new();
    }
}
