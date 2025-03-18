using Application.DTOs.Entidades;
using Application.Interfaces.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/tipos")]
    public class TiposController : ControllerBase
    {
        private readonly ITipoService _tipoService;

        public TiposController(ITipoService tipoService)
        {
            _tipoService = tipoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _tipoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipo = await _tipoService.GetByIdAsync(id);
            return tipo is null ? NotFound() : Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TipoRequestDTO dto)
        {
            var tipo = await _tipoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = tipo.Id }, tipo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TipoRequestDTO dto)
        {
            var update = await _tipoService.UpdateAsync(id, dto);
            return update ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _tipoService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
