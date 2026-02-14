using OmniGov.Core.Interfaces;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRptAuctionRepository : IRepository<RptAuctionModel>
    {
        DataTable GetAuctionProperties(RptAuctionModel rptAuctionModel);

        DataTable GetAuctionProperties(int auctionId);

        Dictionary<string, string> GetAuctionPropertiesByAuctionIdAndTaxpayerId(int auctionId, int taxpayerId);

        Dictionary<string, string> GetAuctionPropertiesByAuctionIdAndRptId(int auctionId, int rptId);

        DataTable GetBiddersByAuctionAndPropertyId(int auctionId, int rptId);

        DataTable GetViewRecords(string searchKey, DateTime date, int rowFilter);
    }
}