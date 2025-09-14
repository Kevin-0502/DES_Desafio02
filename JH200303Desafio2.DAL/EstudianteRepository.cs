using Dapper;
using JH200303Desafio2.DAL.Interfaces;
using JH200303Desafio2.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH200303Desafio2.DAL
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly IDatabaseRepository databaseRepository;

        public EstudianteRepository(IDatabaseRepository databaseRepository)
        {
            this.databaseRepository = databaseRepository;
        }

        public async Task<List<Estudiante>> GetEstudiantesAsync()
        {
            string query = "SELECT * FROM Estudiante";
            return await databaseRepository.GetDataByQueryAsync<Estudiante>(query);
        }

        public async Task<Estudiante> GetEstudianteByIdAsync(int id)
        {
            string query = "SELECT * FROM Estudiante WHERE IdEstudiante = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return (await databaseRepository.GetDataByQueryAsync<Estudiante>(query, parameters)).FirstOrDefault();
        }

        public async Task<int> InsertEstudianteAsync(Estudiante estudiante)
        {
            string query = "INSERT INTO Estudiante (Nombre, Email, FechaNacimiento) " +
                           "VALUES (@Nombre, @Email, @FechaNacimiento); SELECT SCOPE_IDENTITY();";
            var parameters = new DynamicParameters(estudiante);
            return await databaseRepository.InsertAsync<int>(query, parameters);
        }

        public async Task<Estudiante> UpdateEstudianteAsync(Estudiante estudiante)
        {
            string query = "UPDATE Estudiante SET Nombre = @Nombre, Email = @Email, FechaNacimiento = @FechaNacimiento " +
                           "WHERE IdEstudiante = @IdEstudiante";
            var parameters = new DynamicParameters(estudiante);
            await databaseRepository.UpdateAsync<int>(query, parameters);
            return estudiante;
        }

        public async Task<bool> DeleteEstudianteAsync(int id)
        {
            string query = "DELETE FROM Estudiante WHERE IdEstudiante = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await databaseRepository.DeleteAsync<bool>(query, parameters);
        }
    }
}
