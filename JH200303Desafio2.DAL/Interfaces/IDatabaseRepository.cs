using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JH200303Desafio2.Common;

namespace JH200303Desafio2.DAL.Interfaces
{
    public interface IDatabaseRepository
    {
        public Task<List<T>> GetDataByQueryAsync<T>(string query, DynamicParameters? parameters = null);

        public Task<int> InsertAsync<T>(string storeProcedure, DynamicParameters? parameters = null);

        public Task<T> UpdateAsync<T>(string storeProcedure, DynamicParameters? parameters = null);

        public Task<bool> DeleteAsync<T>(string storeProcedure, DynamicParameters? parameters = null);

    }
}
