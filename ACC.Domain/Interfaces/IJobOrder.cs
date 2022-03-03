using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IJobOrder:IRepository<JobOrderModel>
    {
        bool IsUserJobOrder(int userId);

        bool AssignJOToRegular(int regularCollectorId, int joCollectorId);

        int GetJobOrderIdByUserId(int userId);

        DataTable GetViewRecordsByCollectingOfficerId(int collectingOfficerId);

        DataTable GetViewRecordsByCollectingOfficerIdAndBySearchKey(int collectingOfficerId, string searchKey);


    }
}
