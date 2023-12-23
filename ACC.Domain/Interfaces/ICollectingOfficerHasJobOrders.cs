using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ICollectingOfficerHasJobOrders : IAccRepository<CollectingOfficerHasJobOrdersModel>
    {
        DataTable GetViewRecords();

        DataTable GetRecordsBySearch(int collectingOfficerId, string searchText);

        DataTable GetJobOrdersByCollectingOfficerId(int collectingOfficerId);

        int GetCollectingOfficerIDByJobOrderId(int? collectingOfficerId);

        Dictionary<string, string> GetViewRecordByJobOrderUserId(int jobOrderUserId);

        bool IsJobOrderCollector(int jobOrderId);
    }
}