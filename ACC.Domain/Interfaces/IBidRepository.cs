using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IBidRepository : IAccRepository<BidModel>
    {
        Dictionary<string, string> GetHighestBidderByAuctionIdAndRptId(int rptAuctionId, int rptId);
        Dictionary<string, string> GetRecordByAuctionIdAndBidderId(int rptAuctionId, int biddersId);
        Dictionary<string, string> GetViewRecordById(int bidId);
        DataTable GetViewRecords();

        bool UpdateBidDetails(BiddersModel biddersModel, BidModel bidModel);

        DataTable GetViewRecordsByAuctionId(int auctionId);
    }
}
