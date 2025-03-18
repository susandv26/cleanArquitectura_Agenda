using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades;
using Application.Interfaces.Entidades;
using Dominio.Entities;

namespace Application.Services.Entidades
{
    public class TipoService : ITipoService
    {
        private readonly ITipoRepository _tipoRepository;

        public TipoService(ITipoRepository tipoRepository)
        {
            _tipoRepository = tipoRepository;
        }

        public async Task<IEnumerable<TipoResponseDTO>> GetAllAsync()
        {
            var tipos= await _tipoRepository.GetAllAsync();
            return tipos.Select(p => new TipoResponseDTO { Id = p.Id, Nombre = p.Nombre });
        }

        public async Task<TipoResponseDTO> GetByIdAsync(int id)
        {
            var tipo = await _tipoRepository.GetByIdAsync(id);
            return tipo is null ? null : new TipoResponseDTO { Id = tipo.Id, Nombre = tipo.Nombre };

        }

        public async Task<TipoResponseDTO> CreateAsync(TipoRequestDTO dto)
        {
            var tipo = new Dominio.Entities.Tipo(dto.Nombre);
            await _tipoRepository.AddAsync(tipo);
            return new TipoResponseDTO { Id = tipo.Id, Nombre = tipo.Nombre };
        }

        public async Task<bool> UpdateAsync(int id, TipoRequestDTO dto)
        {
            var product = await _tipoRepository.GetByIdAsync(id);

            if (product is null)
                return false;

            product.Nombre = dto.Nombre;

            return await _tipoRepository.UpdateAsync(product);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _tipoRepository.DeleteAsync(id);
        }
    }
}
