using MySql.Data.MySqlClient;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Data.Common;

namespace OmniGov.Core.Services
{
    public enum DatabaseTarget { Lfs, Rpt }

    public class GenericCommands : IGenericCommands
    {
        private readonly IConnectionProvider? _connectionProvider;
        private readonly DatabaseTarget _target;

        public GenericCommands(IConnectionProvider connectionProvider) : this(connectionProvider, DatabaseTarget.Lfs)
        {
        }

        public GenericCommands(IConnectionProvider connectionProvider, DatabaseTarget target)
        {
            _connectionProvider = connectionProvider;
            _target = target;
        }

        private string GetConnectionString()
        {
            string? connectionString = _connectionProvider?.GetConnectionString(_target == DatabaseTarget.Rpt);

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException($"GenericCommands cannot execute: No connection available for {_target}. Ensure a server profile is selected.");

            return connectionString;
        }

        private void AddDbParameter(MySqlCommand command, object[] param)
        {
            DbParameter dbParameter = command.CreateParameter();
            dbParameter.ParameterName = param[0].ToString();
            dbParameter.DbType = (DbType)param[1];
            dbParameter.Value = param[2];
            command.Parameters.Add(dbParameter);
        }

        private void AddDbParameters(MySqlCommand command, IDataParameter[] parameters)
        {
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.Add(param);
                }
            }
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

        public DataTable FillBySearch(string query, DataTable dataTable, object[][] parameters)
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

        public DataTable FillBySearch(string query, DataTable dataTable, params IDataParameter[] parameters)
        {
            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                var adapter = new MySqlDataAdapter();
                using (adapter.SelectCommand = new MySqlCommand(query, connection))
                {
                    AddDbParameters(adapter.SelectCommand, parameters);
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        public bool ExecuteNonQuery(string query, object[][] parameters)
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

        public bool ExecuteNonQuery(string query, params IDataParameter[] parameters)
        {
            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    AddDbParameters(command, parameters);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ExecuteNonQuery(string query)
        {
            return ExecuteNonQuery(query, Array.Empty<IDataParameter>());
        }

        public int ExecuteNonQueryId(string query, object[][] parameters)
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

        public int ExecuteNonQueryId(string query, params IDataParameter[] parameters)
        {
            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    AddDbParameters(command, parameters);
                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        return (int)command.LastInsertedId;
                    return 0;
                }
            }
        }

        public int ExecuteNonQueryId(string query)
        {
            return ExecuteNonQueryId(query, Array.Empty<IDataParameter>());
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

        public DataTable ExecuteReader(string query, IDataParameter[] parameters)
        {
            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    AddDbParameters(command, parameters);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    return dataTable;
                }
            }
        }

        public DataTable ExecuteReader(string query)
        {
            return ExecuteReader(query, Array.Empty<IDataParameter>());
        }

        public string ExecuteScalar(string query, object[][] parameters)
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

        public string ExecuteScalar(string query, params IDataParameter[] parameters)
        {
            using (var connection = new MySqlConnection(GetConnectionString()))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    AddDbParameters(command, parameters);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    return result != null ? result.ToString() : string.Empty;
                }
            }
        }

        public string ExecuteScalar(string query)
        {
            return ExecuteScalar(query, Array.Empty<IDataParameter>());
        }

        public bool TestConnection(string connectionString)
        {
            try
            {
                var builder = new MySqlConnectionStringBuilder(connectionString)
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