using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IJobOrder:IRepository<JobOrderModel>
    {
        bool IsUserJobOrder(int userId);

        DataTable GetViewRecordsByCollectingOfficerId(int collectingOfficerId);
    }
}
