using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.AggregateRoots;
using Dominio.Common;

namespace Dominio.Entities
{
    public class ReseñaVehiculo:Entity
    {
        public int IdUsuarioHuesped { get; set; }
        public int IdVehiculo { get; set; }
        public DateTime FechaReseña { get; set; }
        public string Comentario { get; set; }
        public int IdValoracion { get; set; }

        // Navegación
        public Usuario? UsuarioHuesped { get; set; }
        public Vehiculo? Vehiculo { get; set; }
        public Valoracion? Valoracion { get; set; }
    }
}
