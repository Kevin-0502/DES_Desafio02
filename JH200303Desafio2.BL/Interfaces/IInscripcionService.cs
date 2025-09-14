using JH200303Desafio2.Entites.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.BL.Interfaces
{
    public interface IInscripcionService
    {
        public Task<List<InscripcionDto>> GetInscripcionesAsync();
        public Task<InscripcionDto> GetInscripcionByIdAsync(int id);
        public Task<int> InsertInscripcionAsync(InscripcionDto inscripcion);
        public Task<InscripcionDto> UpdateInscripcionAsync(InscripcionDto inscripcion);
        public Task<bool> DeleteInscripcionAsync(int id);
    }
}
