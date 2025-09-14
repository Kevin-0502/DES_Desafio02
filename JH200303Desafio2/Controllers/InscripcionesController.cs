using JH200303Desafio2.BL.Interfaces;
using JH200303Desafio2.Entites.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JH200303Desafio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionController : ControllerBase
    {
        private readonly IInscripcionService _inscripcionService;

        public InscripcionController(IInscripcionService inscripcionService)
        {
            _inscripcionService = inscripcionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<InscripcionDto>>> Get()
        {
            var inscripciones = await _inscripcionService.GetInscripcionesAsync();
            if (inscripciones == null || !inscripciones.Any())
                return NotFound("No se encontraron inscripciones.");
            return Ok(inscripciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InscripcionDto>> Get(int id)
        {
            var inscripcion = await _inscripcionService.GetInscripcionByIdAsync(id);
            if (inscripcion == null)
                return NotFound("Inscripción no encontrada.");
            return Ok(inscripcion);
        }

        [HttpPost]
        public async Task<ActionResult<InscripcionDto>> Post([FromBody] InscripcionDto inscripcionDto)
        {
            var id = await _inscripcionService.InsertInscripcionAsync(inscripcionDto);
            if (id <= 0)
                return BadRequest("No se pudo crear la inscripción.");

            inscripcionDto.IdInscripcion = id;
            return CreatedAtAction(nameof(Get), new { id = inscripcionDto.IdInscripcion }, inscripcionDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] InscripcionDto inscripcionDto)
        {
            if (id != inscripcionDto.IdInscripcion)
                return BadRequest("El ID no coincide.");

            var actualizado = await _inscripcionService.UpdateInscripcionAsync(inscripcionDto);
            if (actualizado == null)
                return NotFound("No se pudo actualizar la inscripción.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _inscripcionService.DeleteInscripcionAsync(id);
            if (!eliminado)
                return NotFound("No se pudo eliminar la inscripción.");

            return NoContent();
        }
    }
}
