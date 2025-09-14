using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.Entites.Models
{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        // Relación: un estudiante puede tener muchas inscripciones
        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
