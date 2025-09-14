using JH200303Desafio2.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.DAL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryConnector(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseRepository, DatabaseRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<ICursoRepository, CursoRepository>();
            services.AddTransient<IEstudianteRepository, EstudianteRepository>();
            services.AddTransient<IInscripcionRepository, InscripcionRepository>();
            return services;
        }
    }
}
