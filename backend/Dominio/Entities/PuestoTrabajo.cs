﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Common;

namespace Dominio.Entities
{
    public class PuestoTrabajo:EntityCatalog
    {
        public PuestoTrabajo(string descripcion)
        {
            Descripcion = descripcion;
        }

        public int IdArea { get; set; }
        public AreaTrabajo? Area { get; set; }
    }
}
