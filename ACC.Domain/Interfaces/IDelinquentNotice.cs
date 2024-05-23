using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IDelinquentNotice : IAccRepository<DelinquentNoticeModel>
    {
        public DataTable GetViewRecordsBySearch(int rowLimit, string searchKey);
    }
}