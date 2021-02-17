using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IDbGenericCommands
    {
        DataTable Fill(string query, DataTable dataTable);
        DataTable FillBySearch(string query, DataTable dataTable, params object[][] parameters);
        bool ExecuteNonQuery(string query, params object[][] parameters);
        DataTable ExecuteReader(string query, params object[][] parameters);
        dynamic ExecuteScalar(string query, params object[][] parameters);
    }
}