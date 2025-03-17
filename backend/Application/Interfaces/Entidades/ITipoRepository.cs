using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Entidades
{
    public interface ITipoRepository
    {
        Task<IEnumerable<Tipo>> GetAllAsync();
        Task<Tipo?> GetByIdAsync(int id);
        Task AddAsync(Tipo tipo);
        Task<bool> UpdateAsync(Tipo tipo);
        Task<bool> DeleteAsync(int id);
    }
}
