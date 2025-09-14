using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.Entites.DTO
{
    public class InscripcionDto
    {
        public int IdInscripcion { get; set; }

        [Required(ErrorMessage = "La fecha de inscripción es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaInscripcion { get; set; }

        [Required(ErrorMessage = "El Id del estudiante es requerido")]
        public int IdEstudiante { get; set; }

        [Required(ErrorMessage = "El Id del curso es requerido")]
        public int IdCurso { get; set; }
    }
}
