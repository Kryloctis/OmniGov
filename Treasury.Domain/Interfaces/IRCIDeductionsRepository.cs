using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
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
