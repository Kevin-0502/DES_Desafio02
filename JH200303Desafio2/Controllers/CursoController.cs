using JH200303Desafio2.BL.Interfaces;
using JH200303Desafio2.Entites.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JH200303Desafio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CursoDto>>> Get()
        {
            var cursos = await _cursoService.GetCursosAsync();
            if (cursos == null || !cursos.Any())
                return NotFound("No se encontraron cursos.");
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CursoDto>> Get(int id)
        {
            var curso = await _cursoService.GetCursoByIdAsync(id);
            if (curso == null)
                return NotFound("Curso no encontrado.");
            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult<CursoDto>> Post([FromBody] CursoDto cursoDto)
        {
            var id = await _cursoService.InsertCursoAsync(cursoDto);
            if (id <= 0)
                return BadRequest("No se pudo crear el curso.");

            cursoDto.IdCurso = id;
            return CreatedAtAction(nameof(Get), new { id = cursoDto.IdCurso }, cursoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CursoDto cursoDto)
        {
            if (id != cursoDto.IdCurso)
                return BadRequest("El ID no coincide.");

            var actualizado = await _cursoService.UpdateCursoAsync(cursoDto);
            if (actualizado == null)
                return NotFound("No se pudo actualizar el curso.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _cursoService.DeleteCursoAsync(id);
            if (!eliminado)
                return NotFound("No se pudo eliminar el curso.");

            return NoContent();
        }
    }
}
