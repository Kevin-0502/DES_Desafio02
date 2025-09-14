using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.Entites.Models
{
    public class Inscripcion
    {
        public int IdInscripcion { get; set; }

        [Required]
        public DateTime FechaInscripcion { get; set; }

        // Claves foráneas
        public int IdEstudiante { get; set; }
        public Estudiante Estudiante { get; set; }

        public int IdCurso { get; set; }
        public Curso Curso { get; set; }
    }
}
