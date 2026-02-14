using OmniGov.Core.Interfaces;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRptLevy : IRepository<RptLevyModel>
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