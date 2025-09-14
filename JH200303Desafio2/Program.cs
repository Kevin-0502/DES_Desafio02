using JH200303Desafio2.BL.Automapper;
using JH200303Desafio2.BL.Interfaces;
using JH200303Desafio2.BL;
using JH200303Desafio2.DAL;
using JH200303Desafio2.DAL.Interfaces;
using JH200303Desafio2.Common;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Configurar AppSettings
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Registrar DatabaseRepository
builder.Services.AddTransient<IDatabaseRepository, DatabaseRepository>();

// Registrar Repositorios
builder.Services.AddTransient<IEstudianteRepository, EstudianteRepository>();
builder.Services.AddTransient<IInstructorRepository, InstructorRepository>();
builder.Services.AddTransient<ICursoRepository, CursoRepository>();
builder.Services.AddTransient<IInscripcionRepository, InscripcionRepository>();

// Registrar Servicios
builder.Services.AddTransient<IEstudianteService, EstudianteService>();
builder.Services.AddTransient<IInstructorService, InstructorService>();
builder.Services.AddTransient<ICursoService, CursoService>();
builder.Services.AddTransient<IInscripcionService, InscripcionService>();

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(AutomapperProfile).Assembly);

// Agregar controladores
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
