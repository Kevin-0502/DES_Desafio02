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
    public class InscripcionRepository : IInscripcionRepository
    {
        private readonly IDatabaseRepository databaseRepository;

        public InscripcionRepository(IDatabaseRepository databaseRepository)
        {
            this.databaseRepository = databaseRepository;
        }

        public async Task<List<Inscripcion>> GetInscripcionesAsync()
        {
            string query = "SELECT * FROM Inscripcion";
            return await databaseRepository.GetDataByQueryAsync<Inscripcion>(query);
        }

        public async Task<Inscripcion> GetInscripcionByIdAsync(int id)
        {
            string query = "SELECT * FROM Inscripcion WHERE IdInscripcion = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return (await databaseRepository.GetDataByQueryAsync<Inscripcion>(query, parameters)).FirstOrDefault();
        }

        public async Task<int> InsertInscripcionAsync(Inscripcion inscripcion)
        {
            string query = "INSERT INTO Inscripcion (FechaInscripcion, IdEstudiante, IdCurso) " +
                           "VALUES (@FechaInscripcion, @IdEstudiante, @IdCurso); SELECT SCOPE_IDENTITY();";
            var parameters = new DynamicParameters(inscripcion);
            return await databaseRepository.InsertAsync<int>(query, parameters);
        }

        public async Task<Inscripcion> UpdateInscripcionAsync(Inscripcion inscripcion)
        {
            string query = "UPDATE Inscripcion SET FechaInscripcion = @FechaInscripcion, IdEstudiante = @IdEstudiante, IdCurso = @IdCurso " +
                           "WHERE IdInscripcion = @IdInscripcion";
            var parameters = new DynamicParameters(inscripcion);
            await databaseRepository.UpdateAsync<int>(query, parameters);
            return inscripcion;
        }

        public async Task<bool> DeleteInscripcionAsync(int id)
        {
            string query = "DELETE FROM Inscripcion WHERE IdInscripcion = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await databaseRepository.DeleteAsync<bool>(query, parameters);
        }
    }
}
