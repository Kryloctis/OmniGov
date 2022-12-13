using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IJobOrder : IAccRepository<JobOrderModel>
    {
        bool IsUserJobOrder(int userId);

        int GetJobOrderIdByUserId(int userId);

        Dictionary<string, string> GetRecordByUserID(int Id);
    }
}