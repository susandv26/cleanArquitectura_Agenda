using Dominio.AggregateRoots.Actividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Actividades
{
    public interface IActividadRepository
    {
        Task<IEnumerable<Actividad>> GetAllAsync();
        Task<Actividad?> GetByIdAsync(int id);
        Task AddAsync(Actividad actividad);
        Task<bool> UpdateAsync(Actividad actividad);
        Task<bool> DeleteAsync(int id);
    }
}
