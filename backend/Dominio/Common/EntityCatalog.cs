using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Common
{
    public abstract class EntityCatalog
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
