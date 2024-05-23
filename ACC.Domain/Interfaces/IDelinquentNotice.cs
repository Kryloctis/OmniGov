using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IDelinquentNotice : IAccRepository<DelinquentNoticeModel>
    {
        public DataTable GetViewRecordsBySearch(int rowLimit, string searchKey);

        public Dictionary<string, string> GetViewRecordById(int Id);
    }
}