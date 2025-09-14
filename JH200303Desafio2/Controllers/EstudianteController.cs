using JH200303Desafio2.BL.Interfaces;
using JH200303Desafio2.Entites.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JH200303Desafio2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;

        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstudianteDto>>> Get()
        {
            var estudiantes = await _estudianteService.GetEstudiantesAsync();
            if (estudiantes == null || !estudiantes.Any())
                return NotFound("No se encontraron estudiantes.");
            return Ok(estudiantes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteDto>> Get(int id)
        {
            var estudiante = await _estudianteService.GetEstudianteByIdAsync(id);
            if (estudiante == null)
                return NotFound("Estudiante no encontrado.");
            return Ok(estudiante);
        }

        [HttpPost]
        public async Task<ActionResult<EstudianteDto>> Post([FromBody] EstudianteDto estudianteDto)
        {
            var id = await _estudianteService.InsertEstudianteAsync(estudianteDto);
            if (id <= 0)
                return BadRequest("No se pudo crear el estudiante.");

            estudianteDto.IdEstudiante = id;
            return CreatedAtAction(nameof(Get), new { id = estudianteDto.IdEstudiante }, estudianteDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EstudianteDto estudianteDto)
        {
            if (id != estudianteDto.IdEstudiante)
                return BadRequest("El ID no coincide.");

            var actualizado = await _estudianteService.UpdateEstudianteAsync(estudianteDto);
            if (actualizado == null)
                return NotFound("No se pudo actualizar el estudiante.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _estudianteService.DeleteEstudianteAsync(id);
            if (!eliminado)
                return NotFound("No se pudo eliminar el estudiante.");

            return NoContent();
        }
    }

}
