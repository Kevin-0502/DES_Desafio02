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
    public class CursoRepository : ICursoRepository
    {
        private readonly IDatabaseRepository databaseRepository;

        public CursoRepository(IDatabaseRepository databaseRepository)
        {
            this.databaseRepository = databaseRepository;
        }

        public async Task<List<Curso>> GetCursosAsync()
        {
            string query = "SELECT * FROM Curso";
            return await databaseRepository.GetDataByQueryAsync<Curso>(query);
        }

        public async Task<Curso> GetCursoByIdAsync(int id)
        {
            string query = "SELECT * FROM Curso WHERE IdCurso = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return (await databaseRepository.GetDataByQueryAsync<Curso>(query, parameters)).FirstOrDefault();
        }

        public async Task<int> InsertCursoAsync(Curso curso)
        {
            string query = "INSERT INTO Curso (Titulo, Descripcion, Nivel, IdInstructor) " +
                           "VALUES (@Titulo, @Descripcion, @Nivel, @IdInstructor); SELECT SCOPE_IDENTITY();";
            var parameters = new DynamicParameters(curso);
            return await databaseRepository.InsertAsync<int>(query, parameters);
        }

        public async Task<Curso> UpdateCursoAsync(Curso curso)
        {
            string query = "UPDATE Curso SET Titulo = @Titulo, Descripcion = @Descripcion, Nivel = @Nivel, IdInstructor = @IdInstructor " +
                           "WHERE IdCurso = @IdCurso";
            var parameters = new DynamicParameters(curso);
            await databaseRepository.UpdateAsync<int>(query, parameters);
            return curso;
        }

        public async Task<bool> DeleteCursoAsync(int id)
        {
            string query = "DELETE FROM Curso WHERE IdCurso = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await databaseRepository.DeleteAsync<bool>(query, parameters);
        }
    }
}
