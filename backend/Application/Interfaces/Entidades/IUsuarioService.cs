using Application.DTOs.Entidades;
using Dominio.Entities;


namespace Application.Interfaces.Entidades
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioResponseDTO>> GetAllAsync();
        Task<UsuarioResponseDTO> GetByIdAsync(int id);
        Task<UsuarioResponseDTO> CreateAsync(UsuarioRequestDTO dto);
        Task<bool> UpdateAsync(int id, UsuarioRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
