using JH200303Desafio2.Entites.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.BL.Interfaces
{
    public interface IEstudianteService
    {
        public Task<List<EstudianteDto>> GetEstudiantesAsync();
        public Task<EstudianteDto> GetEstudianteByIdAsync(int id);
        public Task<int> InsertEstudianteAsync(EstudianteDto estudiante);
        public Task<EstudianteDto> UpdateEstudianteAsync(EstudianteDto estudiante);
        public Task<bool> DeleteEstudianteAsync(int id);
    }
}
