using JH200303Desafio2.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.DAL.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<List<Estudiante>> GetEstudiantesAsync();
        Task<Estudiante> GetEstudianteByIdAsync(int id);
        Task<int> InsertEstudianteAsync(Estudiante estudiante);
        Task<Estudiante> UpdateEstudianteAsync(Estudiante estudiante);
        Task<bool> DeleteEstudianteAsync(int id);
    }
}
