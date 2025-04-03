using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Common;

namespace Dominio.Entities
{
    public class Telefono: Entity
    {
        public string NumTelefono { get; set; }
        public string IdPersona { get; set; }
        public Persona? Persona { get; set; }
    }
}
