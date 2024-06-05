using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IAuctionRepository : IAccRepository<AuctionModel>
    {
        Dictionary<string, string> GetRecordById(int auctionId);

        DataTable GetViewRecords(string searchKey, DateTime date, int rowFilter);

        DataTable GetAuctionSchedule();
    }
}
