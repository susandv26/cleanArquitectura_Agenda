using Application.DTOs.Actividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Actividades
{
    public interface ITareaService
    {
        Task<IEnumerable<TareaResponseDTO>> GetAllAsync();
        Task<TareaResponseDTO> GetByIdAsync(int id);
        Task<TareaResponseDTO> CreateAsync(TareaRequestDTO dto);
        Task<bool> UpdateAsync(int id, TareaRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
