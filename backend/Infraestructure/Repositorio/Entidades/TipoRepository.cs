using Dominio.Entities;
using Application.Interfaces.Entidades;
using Application.Interfaces.Actividades;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositorio.Entidades
{
    public class TipoRepository : ITipoRepository
    {
        private readonly BackendDBContext _context;

        public TipoRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tipo>> GetAllAsync()
        {
            return await _context.Tipos.ToListAsync();
        }

        public async Task<Tipo?> GetByIdAsync(int id)
        {
            return await _context.Tipos.FindAsync(id);
        }

        public async Task AddAsync(Tipo tipo)
        {
            _context.Tipos.Add(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Tipo tipo)
        {
            _context.Tipos.Update(tipo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tipo = await _context.Tipos.FindAsync(id);
            if (tipo is null) return false;

            _context.Tipos.Remove(tipo);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
