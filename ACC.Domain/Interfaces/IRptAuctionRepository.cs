using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRptAuctionRepository : IAccRepository<RptAuctionModel>
    {
        DataTable GetAuctionProperties(RptAuctionModel rptAuctionModel);
        Dictionary<string, string> GetAuctionPropertiesByAuctionIdAndTaxpayerId(int auctionId, int taxpayerId);
        DataTable GetViewRecords(string searchKey, DateTime date, int rowFilter);
    }
}
