﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.AggregateRoots;
using Dominio.Common;

namespace Dominio.Entities
{
    public class DetalleFactura:Entity
    {
        public int IdEncabezadoFactura { get; set; }
        public decimal Subtotal { get; set; }
        public int Impuesto { get; set; }
        public int Descuento { get; set; }
        public decimal Total { get; set; }

        // Propiedad de navegación
        public EncabezadoFactura? EncabezadoFactura { get; set; }
    }
}
