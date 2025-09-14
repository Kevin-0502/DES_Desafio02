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
    public class EstudianteService: IEstudianteService
    {
        private readonly IEstudianteRepository estudianteRepository;
        private readonly IMapper estudianteMapper;

        public EstudianteService(IEstudianteRepository estudianteRepository, IMapper estudianteMapper)
        {
            this.estudianteRepository = estudianteRepository;
            this.estudianteMapper = estudianteMapper;
        }

        public async Task<List<EstudianteDto>> GetEstudiantesAsync()
        {
            try
            {
                var result = await estudianteRepository.GetEstudiantesAsync();
                return estudianteMapper.Map<List<Estudiante>, List<EstudianteDto>>(result);
            }
            catch (Exception ex)
            {
                return new List<EstudianteDto>();
            }

        }

        public async Task<EstudianteDto> GetEstudianteByIdAsync(int id)
        {
            try
            {
                var result = await estudianteRepository.GetEstudianteByIdAsync(id);
                return estudianteMapper.Map<Estudiante, EstudianteDto>(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> InsertEstudianteAsync(EstudianteDto estudiante)
        {
            try
            {
                var estudianteEntity = estudianteMapper.Map<EstudianteDto, Estudiante>(estudiante);
                return await estudianteRepository.InsertEstudianteAsync(estudianteEntity);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<EstudianteDto> UpdateEstudianteAsync(EstudianteDto estudiante)
        {
            try
            {
                var estudianteEntity = estudianteMapper.Map<EstudianteDto, Estudiante>(estudiante);
                var result = await estudianteRepository.UpdateEstudianteAsync(estudianteEntity);
                return estudianteMapper.Map<Estudiante, EstudianteDto>(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteEstudianteAsync(int id)
        {
            try
            {
                return await estudianteRepository.DeleteEstudianteAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
