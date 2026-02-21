using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IDelinquentNotice : IRepository<DelinquentNoticeModel>
    {
        public DataTable GetViewRecordsByRptId(int rptId, string noticeType);

        public DataTable GetViewRecords(string noticeType);

        public DataTable GetViewRecordsBySearch(int rowLimit, string searchKey);

        public Dictionary<string, string> GetViewRecordById(int Id);

        public Dictionary<string, string> GetDelinquencyStatusByRptId(int rptId);
    }
}
