using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entities;
using Application.DTOs.Entidades;
using Application.Interfaces.Entidades;

namespace Application.Services.Entidades
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioResponseDTO>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return usuarios.Select(p => new UsuarioResponseDTO { Id = p.Id, Nombre = p.Nombre });
        }

        public async Task<UsuarioResponseDTO> GetByIdAsync (int id)
            {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            return usuario is null ? null : new UsuarioResponseDTO { Id = usuario.Id, Nombre=usuario.Nombre };

        }


        public async Task<UsuarioResponseDTO> CreateAsync(UsuarioRequestDTO dto)
        {
            var usuario = new Dominio.Entities.Usuario(dto.Nombre, dto.Correoelectronico, dto.Password);
            await _usuarioRepository.AddAsync(usuario);
            return new UsuarioResponseDTO { Id = usuario.Id, Nombre = dto.Nombre, };
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

       
        public async Task<bool> UpdateAsync(int id, UsuarioRequestDTO dto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario is null)
                return false;

            usuario.Nombre = dto.Nombre;

            return await _usuarioRepository.UpdateAsync(usuario);
        }
    }
    }

