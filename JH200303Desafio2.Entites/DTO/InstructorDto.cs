using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.Entites.DTO
{
    public class InstructorDto
    {
        public int IdInstructor { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La especialidad es requerida")]
        [StringLength(100, ErrorMessage = "La especialidad no puede tener más de 100 caracteres.")]
        public string Especialidad { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        [StringLength(100, ErrorMessage = "El email no puede tener más de 100 caracteres.")]
        public string Email { get; set; } = string.Empty;
    }
}
