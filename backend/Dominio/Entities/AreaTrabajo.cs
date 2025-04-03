using Dominio.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class AreaTrabajo : EntityCatalog
    {
        public AreaTrabajo(string Descripcion)
        {
            this.Descripcion = Descripcion;
        }
    }
}
