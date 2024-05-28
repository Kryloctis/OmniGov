using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IDelinquentNotice : IAccRepository<DelinquentNoticeModel>
    {
        public DataTable GetViewRecordsByRptId(int rptId, string noticeType);

        public DataTable GetViewRecords(string noticeType);

        public DataTable GetViewRecordsBySearch(int rowLimit, string searchKey);

        public Dictionary<string, string> GetViewRecordById(int Id);
    }
}