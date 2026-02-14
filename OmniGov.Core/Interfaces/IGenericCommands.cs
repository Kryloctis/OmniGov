using System.Data;

namespace OmniGov.Core.Interfaces
{
    public interface IGenericCommands
    {
        bool TestConnection(string testConnectionName);

        DataTable Fill(string query, DataTable dataTable);

        DataTable FillBySearch(string query, DataTable dataTable, params object[][] parameters);

        bool ExecuteNonQuery(string query, params object[][] parameters);

        DataTable ExecuteReader(string query, params object[][] parameters);

        string ExecuteScalar(string query, params object[][] parameters);

        int ExecuteNonQueryId(string query, params object[][] parameters);
    }
}