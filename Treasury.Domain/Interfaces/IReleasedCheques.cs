using OmniGov.Core.Interfaces;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
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