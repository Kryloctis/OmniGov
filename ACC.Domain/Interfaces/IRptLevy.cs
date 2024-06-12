using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRptLevy : IAccRepository<RptLevyModel>
    {
        DataTable GetViewRecordsBySearch(int rowLimit, string searchKey);

        Dictionary<string, string> GetViewRecordById(int Id);

        DataTable GetViewRecords(int rptId);

        DataTable GetViewRecords();
    }
}