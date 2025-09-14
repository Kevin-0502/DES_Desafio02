using Dapper;
using JH200303Desafio2.DAL.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JH200303Desafio2.Common;

namespace JH200303Desafio2.DAL
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly string _connectionString;

        public DatabaseRepository(IOptions<AppSettings> appSettings)
        {
            _connectionString = appSettings.Value.ConnectionString;
        }

        // SELECT
        public async Task<List<T>> GetDataByQueryAsync<T>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                var result = await connection.QueryAsync<T>(query, parameters);
                return result.AsList(); // Devuelve siempre una lista (no null)
            }
            catch (Exception ex)
            {
                throw new Exception("Error en GetDataByQuery: " + ex.Message);
            }
        }

        // INSERT
        public async Task<int> InsertAsync<T>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                var result = await connection.ExecuteScalarAsync<int>(query, parameters); // Devuelve el ID insertado
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en InsertAsync: " + ex.Message);
            }
        }

        // UPDATE
        public async Task<T> UpdateAsync<T>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                await connection.ExecuteAsync(query, parameters); // Ejecuta la actualización
                return default(T)!; // Devuelve default porque ya tienes el objeto
            }
            catch (Exception ex)
            {
                throw new Exception("Error en UpdateAsync: " + ex.Message);
            }
        }

        // DELETE
        public async Task<bool> DeleteAsync<T>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                var rowsAffected = await connection.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en DeleteAsync: " + ex.Message);
            }
        }
    }
}
