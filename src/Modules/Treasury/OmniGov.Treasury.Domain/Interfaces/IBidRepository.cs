using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IBidRepository : IRepository<BidModel>
    {
        Dictionary<string, string> GetHighestBidderByAuctionIdAndRptId(int rptAuctionId, int rptId);

        Dictionary<string, string> GetBidderWinnerAndBidDetails(int taxpayersId, int rptId);

        DataTable GetHighestBidderByRptId(int rptId);

        Dictionary<string, string> GetRecordByAuctionIdAndBidderId(int rptAuctionId, int biddersId);

        Dictionary<string, string> GetViewRecordById(int bidId);

        DataTable GetViewRecords();

        bool UpdateBidDetails(BiddersModel biddersModel, BidModel bidModel);

        DataTable GetViewRecordsByAuctionId(int auctionId);

        DataTable GetSoldRpt(int auctionId);
    }
}
