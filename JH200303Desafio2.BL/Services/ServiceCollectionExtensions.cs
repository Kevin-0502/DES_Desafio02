using JH200303Desafio2.BL.Interfaces;
using JH200303Desafio2.BL.Automapper;
using JH200303Desafio2.DAL.Services;
using Microsoft.Extensions.DependencyInjection;


namespace JH200303Desafio2.BL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceConnector(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutomapperProfile).Assembly);
            services.AddTransient<IEstudianteService, EstudianteService>();
            services.AddTransient<IInstructorService, InstructorService>();
            services.AddTransient<ICursoService, CursoService>();
            services.AddTransient<IInscripcionService, InscripcionService>();
            services.AddRepositoryConnector(); // Registrar repositorios
            return services;
        }
    }
}