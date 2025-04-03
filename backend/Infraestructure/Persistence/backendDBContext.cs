using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
     public class BackendDBContext : DbContext
    {
        public BackendDBContext(DbContextOptions<BackendDBContext> options) : base(options) { }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // esta cosa se refiere a que si  se borra una Actividad, se borran sus Tareas
        }

    }
}
