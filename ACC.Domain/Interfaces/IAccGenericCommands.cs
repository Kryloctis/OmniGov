using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IAccGenericCommands
    {
        DataTable Fill(string query, DataTable dataTable);

        DataTable FillBySearch(string query, DataTable dataTable, params object[][] parameters);

        bool ExecuteNonQuery(string query, params object[][] parameters);

        DataTable ExecuteReader(string query, params object[][] parameters);

        string ExecuteScalar(string query, params object[][] parameters);

        int ExecuteNonQueryId(string query, params object[][] parameters);
    }
}