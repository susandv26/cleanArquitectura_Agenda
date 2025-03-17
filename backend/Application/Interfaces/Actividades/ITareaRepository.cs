using Dominio.AggregateRoots.Actividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Actividades
{
    public interface ITareaRepository
    {
        Task<IEnumerable<Tarea>> GetAllAsync();
        Task<Tarea?> GetByIdAsync(int id);
        Task AddAsync(Tarea tarea);
        Task<bool> UpdateAsync(Tarea tarea);
        Task<bool> DeleteAsync(int id);
    }
}
