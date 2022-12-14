using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRCIDeductionsRepository : IAccRepository<RCIDeductionsModel>
    {
        DataTable GetDeductionsByRCIId(int rciId);

        bool DeleteRecordsByRCIId(int rcidId);
    }
}