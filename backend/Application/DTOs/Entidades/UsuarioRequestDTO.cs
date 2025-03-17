using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entidades
{
    public class UsuarioRequestDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Correoelectronico { get; set; }
        public string Password { get; set; }
    }
}
