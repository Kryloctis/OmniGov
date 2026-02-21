using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
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
