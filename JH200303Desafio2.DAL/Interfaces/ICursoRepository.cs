using JH200303Desafio2.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.DAL.Interfaces
{
    public interface ICursoRepository
    {
        Task<List<Curso>> GetCursosAsync();
        Task<Curso> GetCursoByIdAsync(int id);
        Task<int> InsertCursoAsync(Curso curso);
        Task<Curso> UpdateCursoAsync(Curso curso);
        Task<bool> DeleteCursoAsync(int id);
    }
}
