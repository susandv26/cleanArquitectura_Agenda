using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Common;

namespace Dominio.Entities
{
    public class Ciudad: EntityCatalog
    {

        public int DepartamentoId { get; set; }

        public Departamento? Departamento { get; set; }

        public Ciudad(string Descripcion) {

            this.Descripcion = Descripcion;
        
        }
    }
}
