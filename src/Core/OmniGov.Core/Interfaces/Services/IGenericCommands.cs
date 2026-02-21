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
        DataTable FillBySearch(string query, DataTable dataTable, object[][] parameters);

        /// <summary>
        /// Fills a DataTable with results from a parameterized query using standard parameters
        /// </summary>
        DataTable FillBySearch(string query, DataTable dataTable, params IDataParameter[] parameters);

        /// <summary>
        /// Executes a non-query command (INSERT, UPDATE, DELETE)
        /// </summary>
        bool ExecuteNonQuery(string query, object[][] parameters);

        /// <summary>
        /// Executes a non-query command using standard parameters
        /// </summary>
        bool ExecuteNonQuery(string query, params IDataParameter[] parameters);

        /// <summary>
        /// Executes a non-query command (INSERT, UPDATE, DELETE) with no parameters
        /// </summary>
        bool ExecuteNonQuery(string query);

        /// <summary>
        /// Executes a non-query command and returns the last inserted ID
        /// </summary>
        int ExecuteNonQueryId(string query, object[][] parameters);

        /// <summary>
        /// Executes a non-query command and returns last inserted ID using standard parameters
        /// </summary>
        int ExecuteNonQueryId(string query, params IDataParameter[] parameters);

        /// <summary>
        /// Executes a non-query command with no parameters and returns last inserted ID
        /// </summary>
        int ExecuteNonQueryId(string query);

        /// <summary>
        /// Executes a query and returns results as DataTable
        /// </summary>
        DataTable ExecuteReader(string query, object[][] parameters);

        /// <summary>
        /// Executes a query and returns results using standard parameters
        /// </summary>
        DataTable ExecuteReader(string query, IDataParameter[] parameters);

        /// <summary>
        /// Executes a query and returns results with no parameters
        /// </summary>
        DataTable ExecuteReader(string query);

        /// <summary>
        /// Executes a scalar query and returns a single value
        /// </summary>
        string ExecuteScalar(string query, object[][] parameters);

        /// <summary>
        /// Executes a scalar query using standard parameters
        /// </summary>
        string ExecuteScalar(string query, params IDataParameter[] parameters);

        /// <summary>
        /// Executes a scalar query with no parameters
        /// </summary>
        string ExecuteScalar(string query);

        /// <summary>
        /// Tests the database connection
        /// </summary>
        bool TestConnection(string connectionString);
    }
}

