using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Common;

namespace Dominio.Entities
{
    public class Rol : EntityCatalog
    {
        public Rol(string descripcion)
        {
            Descripcion = descripcion;
        }
    }
}
