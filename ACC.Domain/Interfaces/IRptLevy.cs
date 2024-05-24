using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRptLevy : IAccRepository<RptLevyModel>
    {
        DataTable GetViewRecordsBySearch(int rowLimit, string searchKey);

        DataTable GetViewRecordById(int Id);
    }
}