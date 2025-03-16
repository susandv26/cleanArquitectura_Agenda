using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.AggregateRoots.Actividades;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
     public class BackendDBContext : DbContext
    {
        public BackendDBContext(DbContextOptions<BackendDBContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Actividad>()
             .HasOne(a => a.Usuario)
             .WithMany()
             .HasForeignKey(a => a.UsuarioId)
             .OnDelete(DeleteBehavior.Restrict);

            // Actividad -> Tipo
            modelBuilder.Entity<Actividad>()
                .HasOne(a => a.Tipo)
                .WithMany()
                .HasForeignKey(a => a.TipoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Tarea -> Actividad
            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Actividad)
                .WithMany(a => a.Tareas)
                .HasForeignKey(t => t.ActividadId)
                .OnDelete(DeleteBehavior.Cascade); // esta cosa se refiere a que si  se borra una Actividad, se borran sus Tareas
        }

    }
}
