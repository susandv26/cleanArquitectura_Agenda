using Application.DTOs.Actividades;
using Application.Interfaces.Actividades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/tareas")]
    public class TareasController : ControllerBase
    {
        private readonly ITareaService _tareaService;

        public TareasController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _tareaService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tarea = await _tareaService.GetByIdAsync(id);
            return tarea is null ? NotFound() : Ok(tarea);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TareaRequestDTO dto)
        {
            var tarea = await _tareaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = tarea.Id }, tarea);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TareaRequestDTO dto)
        {
            var update = await _tareaService.UpdateAsync(id, dto);
            return update ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _tareaService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
