using MySql.Data.MySqlClient;
using RPT.Domain.Interfaces;
using System.Data;
using System.Data.Common;

namespace RPT.Data
{
    public class RptGenericCommands : IRPTGenericCommands
    {
        private readonly string connectionString;

        public RptGenericCommands(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private void AddDbParameter(MySqlCommand command, object[] param)
        {
            DbParameter dbParameter = command.CreateParameter();
            dbParameter.ParameterName = param[0].ToString();
            dbParameter.DbType = (DbType)param[1];
            dbParameter.Value = param[2];
            command.Parameters.Add(dbParameter);
        }

        public DataTable Fill(string query, DataTable dtOffice)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(query, connection);
                adapter.Fill(dtOffice);
            }

            return dtOffice;
        }

        public DataTable FillBySearch(string query, DataTable dtOffice, params object[][] parameters)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var adapter = new MySqlDataAdapter();
                using (adapter.SelectCommand = new MySqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                        AddDbParameter(adapter.SelectCommand, param);

                    adapter.Fill(dtOffice);
                }
            }

            return dtOffice;
        }

        public bool ExecuteNonQuery(string query, params object[][] parameters)
        {
            using (var connection = new MySqlConnection(connectionString))
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
            using (var connection = new MySqlConnection(connectionString))
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
            using (var connection = new MySqlConnection(connectionString))
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
            using (var connection = new MySqlConnection(connectionString))
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

        public bool TestConnection(string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                if (connection.Ping())
                    return true;
                return false;
            }
        }
    }
}