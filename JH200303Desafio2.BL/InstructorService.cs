using AutoMapper;
using JH200303Desafio2.BL.Interfaces;
using JH200303Desafio2.DAL.Interfaces;
using JH200303Desafio2.Entites.DTO;
using JH200303Desafio2.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.BL
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository instructorRepository;
        private readonly IMapper mapper;

        public InstructorService(IInstructorRepository instructorRepository, IMapper mapper)
        {
            this.instructorRepository = instructorRepository;
            this.mapper = mapper;
        }

        public async Task<List<InstructorDto>> GetInstructoresAsync()
        {
            try
            {
                var result = await instructorRepository.GetInstructoresAsync();
                return mapper.Map<List<Instructor>, List<InstructorDto>>(result);
            }
            catch
            {
                return new List<InstructorDto>();
            }
        }

        public async Task<InstructorDto> GetInstructorByIdAsync(int id)
        {
            try
            {
                var result = await instructorRepository.GetInstructorByIdAsync(id);
                return mapper.Map<Instructor, InstructorDto>(result);
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> InsertInstructorAsync(InstructorDto instructor)
        {
            try
            {
                var entity = mapper.Map<InstructorDto, Instructor>(instructor);
                return await instructorRepository.InsertInstructorAsync(entity);
            }
            catch
            {
                return -1;
            }
        }

        public async Task<InstructorDto> UpdateInstructorAsync(InstructorDto instructor)
        {
            try
            {
                var entity = mapper.Map<InstructorDto, Instructor>(instructor);
                var result = await instructorRepository.UpdateInstructorAsync(entity);
                return mapper.Map<Instructor, InstructorDto>(result);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteInstructorAsync(int id)
        {
            try
            {
                return await instructorRepository.DeleteInstructorAsync(id);
            }
            catch
            {
                return false;
            }
        }
    }
}
