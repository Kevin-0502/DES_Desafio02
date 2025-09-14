using AutoMapper;
using JH200303Desafio2.Entites.DTO;
using JH200303Desafio2.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.BL.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // Add all your mappings here
            CreateMap<Estudiante, EstudianteDto>()
                 .ForMember(dest => dest.IdEstudiante, opt => opt.MapFrom(src => src.IdEstudiante))
                 .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                 .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                 .ForMember(dest => dest.FechaNacimiento, opt => opt.MapFrom(src => src.FechaNacimiento))
                 .ReverseMap();

            // 🔹 Curso
            CreateMap<Curso, CursoDto>()
                .ForMember(dest => dest.IdCurso, opt => opt.MapFrom(src => src.IdCurso))
                .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Nivel, opt => opt.MapFrom(src => src.Nivel))
                .ForMember(dest => dest.IdInstructor, opt => opt.MapFrom(src => src.IdInstructor))
                .ReverseMap();

            // 🔹 Instructor
            CreateMap<Instructor, InstructorDto>()
                .ForMember(dest => dest.IdInstructor, opt => opt.MapFrom(src => src.IdInstructor))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Especialidad, opt => opt.MapFrom(src => src.Especialidad))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();

            // 🔹 Inscripcion
            CreateMap<Inscripcion, InscripcionDto>()
                .ForMember(dest => dest.IdInscripcion, opt => opt.MapFrom(src => src.IdInscripcion))
                .ForMember(dest => dest.FechaInscripcion, opt => opt.MapFrom(src => src.FechaInscripcion))
                .ForMember(dest => dest.IdEstudiante, opt => opt.MapFrom(src => src.IdEstudiante))
                .ForMember(dest => dest.IdCurso, opt => opt.MapFrom(src => src.IdCurso))
                .ReverseMap();
        }
    }
}
