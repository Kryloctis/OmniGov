using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IReleasedCheques : IRepository<ReleasedChequesModel>
    {
        DataTable GetViewRecords();

        DataTable GetViewRecords(int bankAccountID, int fundsID, string txtSeach, bool showReleasedOnly);

        DataTable GetViewRecordsByBankAccountID(int bankAccountIDID);

        DataTable GetViewRecordsByBankAccountIDAndPeriodCoveredUnReleased(int bankAccountID, string periodCovered);

        DataTable GetViewRecordsByBankAccountIDAndPeriodCoveredReleased(int bankAccountID, string periodCovered);
    }
}
