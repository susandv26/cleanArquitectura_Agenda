﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Common;

namespace Dominio.Entities
{
    public class Pais : EntityCatalog
    {
        public Pais(string descripcion)
        {
            Descripcion = descripcion;
        }
    }
}
