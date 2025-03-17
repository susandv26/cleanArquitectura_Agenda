

    using Application.DTOs;
    using Application.DTOs.Entidades;
    using Application.Interfaces;
    using Application.Interfaces.Entidades;
    using Microsoft.AspNetCore.Mvc;

    namespace API.Controllers
    {
        [ApiController]
        [Route("api/usuarios")]
        public class UsuariosController : ControllerBase
        {
            private readonly IUsuarioService _usuarioService;

            public UsuariosController(IUsuarioService usuarioService)
            {
                _usuarioService = usuarioService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _usuarioService.GetAllAsync());
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var usuario = await _usuarioService.GetByIdAsync(id);
                return usuario is null ? NotFound() : Ok(usuario);
            }

            [HttpPost]
            public async Task<IActionResult> Create([FromBody] UsuarioRequestDTO dto)
            {
                var usuario = await _usuarioService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] UsuarioRequestDTO dto)
            {
                var update = await _usuarioService.UpdateAsync(id, dto);
                return update ? NoContent() : NotFound();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var deleted = await _usuarioService.DeleteAsync(id);
                return deleted ? NoContent() : NotFound();
            }
        }
    }


