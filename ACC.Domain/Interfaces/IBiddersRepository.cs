using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IBiddersRepository : IAccRepository<BiddersModel>
    {
        int GetLastInsertedId(int createdById);
        DataTable GetViewRecords();

        DataTable GetViewRecordsByAuctionIdAndBiddersId(int auctionId, int bidderId);

        Dictionary<string, string> GetViewRecordByAuctionIdAndBidderId(int auctionId, int bidderId);

        DataTable GetBiddersByAuctionIdAndRptId(int auctionId, int rptAuctionId);

        bool BidderNoExist(int rptAuction, string bidderNo);
    }

}
