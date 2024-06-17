using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IBidRepository : IAccRepository<BidModel>
    {
        Dictionary<string, string> GetRecordByAuctionIdAndBidderId(int rptAuctionId, int biddersId);

        DataTable GetViewRecords();
    }
}
