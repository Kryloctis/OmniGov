using OmniGov.Core.Interfaces;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface ICollectingOfficerHasJobOrders : IRepository<CollectingOfficerHasJobOrdersModel>
    {
        DataTable GetViewRecords();

        DataTable GetRecordsBySearch(int collectingOfficerId, string searchText);

        DataTable GetJobOrdersByCollectingOfficerId(int collectingOfficerId);

        int GetCollectingOfficerIDByJobOrderId(int? collectingOfficerId);

        Dictionary<string, string> GetViewRecordByJobOrderUserId(int jobOrderUserId);

        bool IsJobOrderCollector(int jobOrderId);
    }
}