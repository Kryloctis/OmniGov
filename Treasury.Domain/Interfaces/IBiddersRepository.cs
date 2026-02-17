using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IBiddersRepository : IRepository<BiddersModel>
    {
        int GetLastInsertedId(int createdById);

        DataTable GetViewRecords();

        DataTable GetViewRecordsByAuctionIdAndBiddersId(int auctionId, int bidderId);

        Dictionary<string, string> GetViewRecordByAuctionIdAndBidderId(int auctionId, int bidderId);

        DataTable GetBiddersByAuctionIdAndRptId(int auctionId, int rptAuctionId);

        bool BidderNoExist(int rptAuction, string bidderNo);
    }
}
