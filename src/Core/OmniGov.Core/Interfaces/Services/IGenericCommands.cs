using System.Data;

namespace OmniGov.Core.Interfaces.Services
{
    /// <summary>
    /// Interface for generic database command operations
    /// </summary>
    public interface IGenericCommands
    {
        /// <summary>
        /// Fills a DataTable with results from a query
        /// </summary>
        DataTable Fill(string query, DataTable dataTable);

        /// <summary>
        /// Fills a DataTable with results from a parameterized query
        /// </summary>
        DataTable FillBySearch(string query, DataTable dataTable, params object[][] parameters);

        /// <summary>
        /// Executes a non-query command (INSERT, UPDATE, DELETE)
        /// </summary>
        bool ExecuteNonQuery(string query, params object[][] parameters);

        /// <summary>
        /// Executes a non-query command and returns the last inserted ID
        /// </summary>
        int ExecuteNonQueryId(string query, params object[][] parameters);

        /// <summary>
        /// Executes a query and returns results as DataTable
        /// </summary>
        DataTable ExecuteReader(string query, object[][] parameters);

        /// <summary>
        /// Executes a scalar query and returns a single value
        /// </summary>
        string ExecuteScalar(string query, params object[][] parameters);

        /// <summary>
        /// Tests the database connection
        /// </summary>
        bool TestConnection(string connectionString);
    }
}

