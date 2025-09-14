using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.Entites.DTO
{
    public class CursoDto
    {
        public int IdCurso { get; set; }

        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(150, ErrorMessage = "El título no puede tener más de 150 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [StringLength(300, ErrorMessage = "La descripción no puede tener más de 300 caracteres.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nivel es requerido")]
        [StringLength(50, ErrorMessage = "El nivel no puede tener más de 50 caracteres.")]
        public string Nivel { get; set; } = string.Empty; // Básico, Intermedio, Avanzado

        [Required(ErrorMessage = "El Id del instructor es requerido")]
        public int IdInstructor { get; set; }
    }
}
