using MySql.Data.MySqlClient;
using OmniGov.Core.Interfaces.Services;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace OmniGov.Core.Services
{
    public class GenericCommands : IGenericCommands
    {
        private readonly IConnectionProvider? _connectionProvider;
        private readonly string? _explicitConnectionName;
        private string? _connectionString;

        public GenericCommands(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        private string GetConnectionString()
        {
            if (_connectionString != null) return _connectionString;

            string? connectionName = _connectionProvider?.GetLfsConnectionName() ?? _explicitConnectionName;

            if (string.IsNullOrWhiteSpace(connectionName))
                throw new InvalidOperationException("GenericCommands cannot execute: No connection name was provided. Ensure the user is logged in.");

            var settings = ConfigurationManager.ConnectionStrings[connectionName];
            if (settings == null)
                throw new InvalidOperationException($"Connection string '{connectionName}' not found in App.config.");

            _connectionString = settings.ConnectionString;
            return _connectionString;
        }

        private void AddDbParameter(MySqlCommand command, object[] param)
        {
            DbParameter dbParameter = command.CreateParameter();
            dbParameter.ParameterName = param[0].ToString();
            dbParameter.DbType = (DbType)param[1];
            dbParameter.Value = param[2];
            command.Parameters.Add(dbParameter);
        }

        public DataTable Fill(string query, DataTable dataTable)
        {
            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                var adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(query, connection);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable FillBySearch(string query, DataTable dataTable, params object[][] parameters)
        {
            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                var adapter = new MySqlDataAdapter();
                using (adapter.SelectCommand = new MySqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                        AddDbParameter(adapter.SelectCommand, param);

                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        public bool ExecuteNonQuery(string query, params object[][] parameters)
        {
            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                        AddDbParameter(command, param);

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        return true;

                    return false;
                }
            }
        }

        public int ExecuteNonQueryId(string query, params object[][] parameters)
        {
            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                        AddDbParameter(command, param);

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        return int.Parse(command.LastInsertedId.ToString());
                    return 0;
                }
            }
        }

        public DataTable ExecuteReader(string query, object[][] parameters)
        {
            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                        AddDbParameter(command, param);

                    connection.Open();
                    var reader = command.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    return dataTable;
                }
            }
        }

        public string ExecuteScalar(string query, params object[][] parameters)
        {
            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                        AddDbParameter(command, param);

                    connection.Open();
                    if (command.ExecuteScalar() != null)
                        return command.ExecuteScalar().ToString();

                    return string.Empty;
                }
            }
        }

        public bool TestConnection(string testConnectionName)
        {
            try
            {
                string testConnectionString = ConfigurationManager.ConnectionStrings[testConnectionName].ConnectionString;
                var builder = new MySqlConnectionStringBuilder(testConnectionString)
                {
                    ConnectionTimeout = 2 // 2 seconds should be enough for a local/fast connection check
                };

                using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (MySqlException) { return false; }
            catch (Exception) { return false; }
        }
    }
}