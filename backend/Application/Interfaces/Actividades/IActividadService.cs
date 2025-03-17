using Application.DTOs.Actividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Actividades
{

    public interface IActividadService
    {
        Task<IEnumerable<ActividadResponseDTO>> GetAllAsync();
        Task<ActividadResponseDTO> GetByIdAsync(int id);
        Task<ActividadResponseDTO> CreateAsync(ActividadRequestDTO dto);
        Task<bool> UpdateAsync(int id, ActividadRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
