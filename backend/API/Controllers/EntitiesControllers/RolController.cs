using Application.DTOs.Entidades.RolDTOs;
using Application.Interfaces.Entidades.RolInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _rolService.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rol = await _rolService.GetByIdAsync(id);
            return rol is null ? NotFound() : Ok(rol);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RolRequestDTO dto)
        {
            var nuevoRol = await _rolService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevoRol.Id }, nuevoRol);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RolRequestDTO dto)
        {
            var actualizado = await _rolService.UpdateAsync(id, dto);
            return actualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _rolService.DeleteAsync(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
