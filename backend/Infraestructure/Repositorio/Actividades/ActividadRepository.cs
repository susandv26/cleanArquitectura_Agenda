using Dominio.AggregateRoots.Actividades;
using Infraestructure.Persistence;
using Application.Interfaces.Entidades;
using Application.Interfaces.Actividades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositorio.Actividades
{
    public class ActividadRepository : IActividadRepository
    {
        private readonly BackendDBContext _context;

        public ActividadRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actividad>> GetAllAsync()
        {
            return await _context.Actividades
                .Include(a => a.Usuario)
                .Include(a => a.Tipo)
                .Include(a => a.Tareas)
                .ToListAsync();
        }

        public async Task<Actividad?> GetByIdAsync(int id)
        {
            return await _context.Actividades
                .Include(a => a.Usuario)
                .Include(a => a.Tipo)
                .Include(a => a.Tareas)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Actividad actividad)
        {
            _context.Actividades.Add(actividad);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Actividad actividad)
        {
            _context.Actividades.Update(actividad);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);
            if (actividad is null) return false;

            _context.Actividades.Remove(actividad);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
