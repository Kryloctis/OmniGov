using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRptAuctionRepository : IAccRepository<RptAuctionModel>
    {
        DataTable GetAuctionProperties(RptAuctionModel rptAuctionModel);
        DataTable GetAuctionProperties(int auctionId);
        Dictionary<string, string> GetAuctionPropertiesByAuctionIdAndTaxpayerId(int auctionId, int taxpayerId);
        Dictionary<string, string> GetAuctionPropertiesByAuctionIdAndRptId(int auctionId, int rptId);
        DataTable GetViewRecords(string searchKey, DateTime date, int rowFilter);
    }
}
