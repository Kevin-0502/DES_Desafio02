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
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository cursoRepository;
        private readonly IMapper mapper;

        public CursoService(ICursoRepository cursoRepository, IMapper mapper)
        {
            this.cursoRepository = cursoRepository;
            this.mapper = mapper;
        }

        public async Task<List<CursoDto>> GetCursosAsync()
        {
            try
            {
                var result = await cursoRepository.GetCursosAsync();
                return mapper.Map<List<Curso>, List<CursoDto>>(result);
            }
            catch
            {
                return new List<CursoDto>();
            }
        }

        public async Task<CursoDto> GetCursoByIdAsync(int id)
        {
            try
            {
                var result = await cursoRepository.GetCursoByIdAsync(id);
                return mapper.Map<Curso, CursoDto>(result);
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> InsertCursoAsync(CursoDto curso)
        {
            try
            {
                var entity = mapper.Map<CursoDto, Curso>(curso);
                return await cursoRepository.InsertCursoAsync(entity);
            }
            catch
            {
                return -1;
            }
        }

        public async Task<CursoDto> UpdateCursoAsync(CursoDto curso)
        {
            try
            {
                var entity = mapper.Map<CursoDto, Curso>(curso);
                var result = await cursoRepository.UpdateCursoAsync(entity);
                return mapper.Map<Curso, CursoDto>(result);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteCursoAsync(int id)
        {
            try
            {
                return await cursoRepository.DeleteCursoAsync(id);
            }
            catch
            {
                return false;
            }
        }
    }
}
