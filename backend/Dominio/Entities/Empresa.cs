using Dominio.Common;

namespace Dominio.Entities
{
    public class Empresa: AggregateRoot
    {
        public string Nombre { get; set; }
        public string Rtn { get; set; }
        public string Correo { get; set; }
        public string CasaMatriz { get; set; }
        public string Telefono { get; set; }

        public List<Sucursal> Sucursal { get; set; } = new();
    }
}