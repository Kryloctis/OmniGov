using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
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
