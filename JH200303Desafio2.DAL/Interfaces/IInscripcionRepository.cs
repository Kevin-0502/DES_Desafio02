using JH200303Desafio2.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.DAL.Interfaces
{
    public interface IInscripcionRepository
    {
        Task<List<Inscripcion>> GetInscripcionesAsync();
        Task<Inscripcion> GetInscripcionByIdAsync(int id);
        Task<int> InsertInscripcionAsync(Inscripcion inscripcion);
        Task<Inscripcion> UpdateInscripcionAsync(Inscripcion inscripcion);
        Task<bool> DeleteInscripcionAsync(int id);
    }
}
