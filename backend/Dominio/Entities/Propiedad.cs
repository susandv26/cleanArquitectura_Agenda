﻿
using Dominio.AggregateRoots;
using Dominio.Common;


namespace Dominio.Entities
{
    public class Propiedad:AggregateRoot
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdDireccion { get; set; }

        public int Capacidad { get; set; }
        public int NumeroHabitaciones { get; set; }
        public int NumeroCamas { get; set; }
        public int CapacidadParqueo { get; set; }
        public decimal PrecioPorNoche { get; set; }

        public int IdAnfitrion { get; set; }
        public int IdEstadoReserva { get; set; }
        public decimal MediaValoracion { get; set; }

        // Navegación
        public Direccion? Direccion { get; set; }
        public Usuario? Anfitrion { get; set; }
        public EstadoReserva? EstadoReserva { get; set; }

        public List<Reserva> Reserva { get; set; } = new();
        public List<ReseñaPropiedad> ReseñaPropiedad { get; set; } = new();
    }
}