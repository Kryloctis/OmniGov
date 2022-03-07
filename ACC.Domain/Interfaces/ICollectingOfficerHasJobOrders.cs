using ACC.Domain.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface ICollectingOfficerHasJobOrders : IRepository<CollectingOfficerHasJobOrdersModel>
    {
        DataTable GetRecordsBySearch(int collectingOfficerId, string searchText);
        DataTable GetJobOrdersByCollectingOfficerId(int collectingOfficerId);
        int GetCollectingOfficerIDByJobOrderId(int collectingOfficerId);
    }
}
