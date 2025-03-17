using Dominio.Entities;
using Infraestructure.Persistence;
using Application.Interfaces.Entidades;
using Microsoft.EntityFrameworkCore;

using Application.Interfaces.Actividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositorio.Entidades
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BackendDBContext _context;

        public UsuarioRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario is null) return false;

            _context.Usuarios.Remove(usuario);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
