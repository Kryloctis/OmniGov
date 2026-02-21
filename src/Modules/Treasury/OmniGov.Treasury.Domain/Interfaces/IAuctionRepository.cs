using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IAuctionRepository : IRepository<AuctionModel>
    {
        Dictionary<string, string> GetRecordById(int auctionId);

        DataTable GetViewRecords(string searchKey, DateTime date, int rowFilter);

        DataTable GetAuctionSchedule();
    }
}
