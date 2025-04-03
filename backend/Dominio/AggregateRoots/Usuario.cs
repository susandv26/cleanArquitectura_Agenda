using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Common;
using Dominio.Entities;

namespace Dominio.AggregateRoots
{
    public class Usuario:AggregateRoot
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Dni { get; set; }     
        public int RolId { get; set; }        
        public Persona? Persona { get; set; }
        public Rol? Rol { get; set; }
    }

}
