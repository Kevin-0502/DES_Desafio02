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
    public class InstructorRepository : IInstructorRepository
    {
        private readonly IDatabaseRepository databaseRepository;

        public InstructorRepository(IDatabaseRepository databaseRepository)
        {
            this.databaseRepository = databaseRepository;
        }

        public async Task<List<Instructor>> GetInstructoresAsync()
        {
            string query = "SELECT * FROM Instructor";
            return await databaseRepository.GetDataByQueryAsync<Instructor>(query);
        }

        public async Task<Instructor> GetInstructorByIdAsync(int id)
        {
            string query = "SELECT * FROM Instructor WHERE IdInstructor = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return (await databaseRepository.GetDataByQueryAsync<Instructor>(query, parameters)).FirstOrDefault();
        }

        public async Task<int> InsertInstructorAsync(Instructor instructor)
        {
            string query = "INSERT INTO Instructor (Nombre, Especialidad, Email) " +
                           "VALUES (@Nombre, @Especialidad, @Email); SELECT SCOPE_IDENTITY();";
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", instructor.Nombre);
            parameters.Add("@Especialidad", instructor.Especialidad);
            parameters.Add("@Email", instructor.Email);
            return await databaseRepository.InsertAsync<int>(query, parameters);
        }

        public async Task<Instructor> UpdateInstructorAsync(Instructor instructor)
        {
            string query = "UPDATE Instructor SET Nombre = @Nombre, Especialidad = @Especialidad, Email = @Email " +
                           "WHERE IdInstructor = @IdInstructor";
            var parameters = new DynamicParameters(instructor);
            await databaseRepository.UpdateAsync<int>(query, parameters);
            return instructor;
        }

        public async Task<bool> DeleteInstructorAsync(int id)
        {
            string query = "DELETE FROM Instructor WHERE IdInstructor = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await databaseRepository.DeleteAsync<bool>(query, parameters);
        }
    }
}
