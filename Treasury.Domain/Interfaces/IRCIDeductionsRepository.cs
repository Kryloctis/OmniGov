using OmniGov.Core.Interfaces.Repositories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRciDeductionsRepository : IRepository<RCIDeductionsModel>
    {
        DataTable GetDeductionsByRCIId(int rciId);

        bool DeleteRecordsByRCIId(int rcidId);
    }
}