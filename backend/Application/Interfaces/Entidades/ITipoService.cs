using Application.DTOs.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Entidades
{
    public interface ITipoService
    {
        Task<IEnumerable<TipoResponseDTO>> GetAllAsync();
        Task<TipoResponseDTO> GetByIdAsync(int id);
        Task<TipoResponseDTO> CreateAsync(TipoRequestDTO dto);
        Task<bool> UpdateAsync(int id, TipoRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
