using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Common;

namespace Dominio.Entities
{
    public class Usuario : Entity
    {
        public string Nombre { get; set; }
        public string Correoelectronico { get; set; }
        public string Password { get; set; }


        public Usuario(string nombre, string correoelectronico, string password)
        {
            Nombre = nombre;
            Correoelectronico = correoelectronico;
            Password = password;
        }
    }
}