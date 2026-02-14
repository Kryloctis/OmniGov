using OmniGov.Core.Interfaces;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRCIDeductionsRepository : IRepository<RCIDeductionsModel>
    {
        DataTable GetDeductionsByRCIId(int rciId);

        bool DeleteRecordsByRCIId(int rcidId);
    }
}