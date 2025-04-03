using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.RolDTOs;
using Application.Interfaces.Entidades.RolInterfaces;
using Dominio.Entities;

namespace Application.Services.Entidades
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;

        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<IEnumerable<RolResponseDTO>> GetAllAsync()
        {
            var roles = await _rolRepository.GetAllAsync();
            return roles.Select(r => new RolResponseDTO
            {
                Id = r.Id,
                Descripcion = r.Descripcion
            });
        }

        public async Task<RolResponseDTO?> GetByIdAsync(int id)
        {
            var rol = await _rolRepository.GetByIdAsync(id);
            return rol is null ? null : new RolResponseDTO
            {
                Id = rol.Id,
                Descripcion = rol.Descripcion
            };
        }

        public async Task<RolResponseDTO> CreateAsync(RolRequestDTO dto)
        {
            var rol = new Rol(dto.Descripcion);
            await _rolRepository.AddAsync(rol);

            return new RolResponseDTO
            {
                Id = rol.Id,
                Descripcion = rol.Descripcion
            };
        }

        public async Task<bool> UpdateAsync(int id, RolRequestDTO dto)
        {
            var rol = await _rolRepository.GetByIdAsync(id);
            if (rol is null) return false;

            rol.Descripcion = dto.Descripcion;
            return await _rolRepository.UpdateAsync(rol);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _rolRepository.DeleteAsync(id);
        }
    }
}
