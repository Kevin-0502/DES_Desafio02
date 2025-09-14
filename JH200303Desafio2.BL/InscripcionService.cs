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
    public class InscripcionService : IInscripcionService
    {
        private readonly IInscripcionRepository inscripcionRepository;
        private readonly IMapper mapper;

        public InscripcionService(IInscripcionRepository inscripcionRepository, IMapper mapper)
        {
            this.inscripcionRepository = inscripcionRepository;
            this.mapper = mapper;
        }

        public async Task<List<InscripcionDto>> GetInscripcionesAsync()
        {
            try
            {
                var result = await inscripcionRepository.GetInscripcionesAsync();
                return mapper.Map<List<Inscripcion>, List<InscripcionDto>>(result);
            }
            catch
            {
                return new List<InscripcionDto>();
            }
        }

        public async Task<InscripcionDto> GetInscripcionByIdAsync(int id)
        {
            try
            {
                var result = await inscripcionRepository.GetInscripcionByIdAsync(id);
                return mapper.Map<Inscripcion, InscripcionDto>(result);
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> InsertInscripcionAsync(InscripcionDto inscripcion)
        {
            try
            {
                var entity = mapper.Map<InscripcionDto, Inscripcion>(inscripcion);
                return await inscripcionRepository.InsertInscripcionAsync(entity);
            }
            catch
            {
                return -1;
            }
        }

        public async Task<InscripcionDto> UpdateInscripcionAsync(InscripcionDto inscripcion)
        {
            try
            {
                var entity = mapper.Map<InscripcionDto, Inscripcion>(inscripcion);
                var result = await inscripcionRepository.UpdateInscripcionAsync(entity);
                return mapper.Map<Inscripcion, InscripcionDto>(result);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteInscripcionAsync(int id)
        {
            try
            {
                return await inscripcionRepository.DeleteInscripcionAsync(id);
            }
            catch
            {
                return false;
            }
        }
    }
}
