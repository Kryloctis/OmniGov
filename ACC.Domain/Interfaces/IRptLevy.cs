using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRptLevy : IAccRepository<RptLevyModel>
    {
        DataTable GetViewRecordsBySearch(int rowLimit, string searchKey);

        Dictionary<string, string> GetViewRecordById(int Id);

        Dictionary<string, string> GetViewCancelledLevy(int Id);

        DataTable GetViewRecords(int rptId);

        DataTable GetCancelledLevy(int rptId);

        DataTable GetViewRecords(DateTime date);

        DataTable GetViewRecords(int rptId, DateTime date);

    }
}