using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio.Common;

namespace Dominio.Entities
{
    public class Modelo:EntityCatalog
    {
        public int IdMarca { get; set; }

        public Marca? Marca { get; set; }
    }

}
