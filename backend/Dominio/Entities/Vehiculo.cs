﻿
using Dominio.AggregateRoots;
using Dominio.Common;

namespace Dominio.Entities

{
    public class Vehiculo:AggregateRoot
    {
        public int IdModelo { get; set; }

        public int IdDireccion { get; set; }
        public int Año { get; set; }
        public int IdTipoVehiculo { get; set; }
        public decimal PrecioDia { get; set; }
        public int IdEstadoReserva { get; set; }

        // Navegación
        public Modelo? Modelo { get; set; }
        public Direccion? Direccion { get; set; }
        public TipoVehiculo? TipoVehiculo { get; set; }
        public EstadoReserva? EstadoReserva { get; set; }

        public List<ReservaVehiculo> ReservaVehiculo { get; set; } = new();
        public List<ReseñaVehiculo> ReseñaVehiculo { get; set; } = new();
    }
}