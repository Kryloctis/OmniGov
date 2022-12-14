using System.Data;

namespace RPT.Domain.Interfaces
{
    public interface IRPTGenericCommands
    {
        DataTable Fill(string query, DataTable dataTable);

        DataTable FillBySearch(string query, DataTable dataTable, params object[][] parameters);

        bool ExecuteNonQuery(string query, params object[][] parameters);

        DataTable ExecuteReader(string query, params object[][] parameters);

        string ExecuteScalar(string query, params object[][] parameters);

        int ExecuteNonQueryId(string query, params object[][] parameters);
    }
}