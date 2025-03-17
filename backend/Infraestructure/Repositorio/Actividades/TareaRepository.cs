using Dominio.AggregateRoots.Actividades;
using Infraestructure.Persistence;
using Application.Interfaces.Entidades;
using Application.Interfaces.Actividades;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Repositorio.Actividades
{
    public class TareaRepository : ITareaRepository
    {
        private readonly BackendDBContext _context;

        public TareaRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarea>> GetAllAsync()
        {
            return await _context.Tareas
                .Include(t => t.Actividad)
                .ToListAsync();
        }

        public async Task<Tarea?> GetByIdAsync(int id)
        {
            return await _context.Tareas
                .Include(t => t.Actividad)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Tarea tarea)
        {
            _context.Tareas.Update(tarea);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea is null) return false;

            _context.Tareas.Remove(tarea);
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
