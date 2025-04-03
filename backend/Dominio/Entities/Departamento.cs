using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Common;


namespace Dominio.Entities
{

    public class Departamento: EntityCatalog
    {
        public Departamento(string descripcion)
        {
            Descripcion = descripcion;
        }
        public int IdPais { get; set; }
        public Pais? Pais { get; set; }
    }
}
