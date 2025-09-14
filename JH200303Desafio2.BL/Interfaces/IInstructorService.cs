using JH200303Desafio2.Entites.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.BL.Interfaces
{
    public interface IInstructorService
    {
        public Task<List<InstructorDto>> GetInstructoresAsync();
        public Task<InstructorDto> GetInstructorByIdAsync(int id);
        public Task<int> InsertInstructorAsync(InstructorDto instructor);
        public Task<InstructorDto> UpdateInstructorAsync(InstructorDto instructor);
        public Task<bool> DeleteInstructorAsync(int id);
    }
}
