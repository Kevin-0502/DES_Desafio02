using JH200303Desafio2.Entites.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.BL.Interfaces
{
    public interface ICursoService
    {
        public Task<List<CursoDto>> GetCursosAsync();
        public Task<CursoDto> GetCursoByIdAsync(int id);
        public Task<int> InsertCursoAsync(CursoDto curso);
        public Task<CursoDto> UpdateCursoAsync(CursoDto curso);
        public Task<bool> DeleteCursoAsync(int id);
    }
}
