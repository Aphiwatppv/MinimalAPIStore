using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace DataAccess.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            // Dependency injection to obtain configuration settings, such as connection strings.
            _config = config;
        }

        /// <summary>
        /// Asynchronously loads data from the database using a stored procedure.
        /// </summary>
        /// <typeparam name="T">The model class that the result set will be mapped to.</typeparam>
        /// <typeparam name="U">The type of the parameters being passed to the stored procedure.</typeparam>
        /// <param name="storedProcedure">The name of the stored procedure to execute.</param>
        /// <param name="parameters">The parameters to pass to the stored procedure.</param>
        /// <param name="connectionId">The name of the connection string to use, which defaults to "Default".</param>
        /// <returns>A collection of model objects populated with the query results.</returns>
        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionId = "Default") // Default connection string name from appsettings.json can be overridden if needed.
        {
            // Establishes a connection to the database using the specified connection string.
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            // Executes the stored procedure asynchronously and returns the result set as a list of model objects.
            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Asynchronously saves data to the database using a stored procedure.
        /// </summary>
        /// <typeparam name="T">The type of the parameters being passed to the stored procedure.</typeparam>
        /// <param name="storedProcedure">The name of the stored procedure to execute.</param>
        /// <param name="parameters">The parameters to pass to the stored procedure.</param>
        /// <param name="connectionId">The name of the connection string to use, which defaults to "Default".</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SaveData<T>(
            string storedProcedure,
            T parameters,
            string connectionId = "Default")
        {
            // Establishes a connection to the database using the specified connection string.
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            // Executes the stored procedure asynchronously without expecting a return value.
            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
