using Application.DTOs.Actividades;
using Application.Interfaces.Actividades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/actividades")]
    public class ActividadesController : ControllerBase
    {
        private readonly IActividadService _actividadService;

        public ActividadesController(IActividadService actividadService)
        {
            _actividadService = actividadService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _actividadService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var actividad = await _actividadService.GetByIdAsync(id);
            return actividad is null ? NotFound() : Ok(actividad);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ActividadRequestDTO dto)
        {
            var actividad = await _actividadService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = actividad.Id }, actividad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActividadRequestDTO dto)
        {
            var update = await _actividadService.UpdateAsync(id, dto);
            return update ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _actividadService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
