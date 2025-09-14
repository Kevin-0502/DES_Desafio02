using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.Entites.Models
{
    public class Curso
    {
        public int IdCurso { get; set; }

        [Required]
        [StringLength(150)]
        public string Titulo { get; set; }

        [StringLength(300)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(50)]
        public string Nivel { get; set; } // "Basico", "Intermedio", "Avanzado"

        // Clave foránea
        public int IdInstructor { get; set; }
        public Instructor Instructor { get; set; }

        // Relación: un curso puede tener muchas inscripciones
        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
