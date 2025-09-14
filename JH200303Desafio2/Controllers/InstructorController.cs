using JH200303Desafio2.BL.Interfaces;
using JH200303Desafio2.Entites.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JH200303Desafio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<InstructorDto>>> Get()
        {
            var instructores = await _instructorService.GetInstructoresAsync();
            if (instructores == null || !instructores.Any())
                return NotFound("No se encontraron instructores.");
            return Ok(instructores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorDto>> Get(int id)
        {
            var instructor = await _instructorService.GetInstructorByIdAsync(id);
            if (instructor == null)
                return NotFound("Instructor no encontrado.");
            return Ok(instructor);
        }

        [HttpPost]
        public async Task<ActionResult<InstructorDto>> Post([FromBody] InstructorDto instructorDto)
        {
            var id = await _instructorService.InsertInstructorAsync(instructorDto);
            if (id <= 0)
                return BadRequest("No se pudo crear el instructor.");

            instructorDto.IdInstructor = id;
            return CreatedAtAction(nameof(Get), new { id = instructorDto.IdInstructor }, instructorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] InstructorDto instructorDto)
        {
            if (id != instructorDto.IdInstructor)
                return BadRequest("El ID no coincide.");

            var actualizado = await _instructorService.UpdateInstructorAsync(instructorDto);
            if (actualizado == null)
                return NotFound("No se pudo actualizar el instructor.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _instructorService.DeleteInstructorAsync(id);
            if (!eliminado)
                return NotFound("No se pudo eliminar el instructor.");

            return NoContent();
        }
    }
}
