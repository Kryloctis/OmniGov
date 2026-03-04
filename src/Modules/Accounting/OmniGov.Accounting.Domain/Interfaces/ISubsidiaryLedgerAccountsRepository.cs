using OmniGov.Accounting.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;
using System.Data;

namespace OmniGov.Accounting.Domain.Interfaces
{
    public interface ISubsidiaryLedgerAccountsRepository : IRepository<SubsidiaryLedgerAccountsModel>
    {
        DataTable GetRecordsByReference(int Id);

        DataTable GetRecordsBySearchByReference(string srchtxt, int Id);

        DataTable GetRecordsByFundAndGeneralLedger(int fundId, int generalLedgerId);

        bool HasSubsidiary(ushort generalLedgerId, byte fundId);

        DataTable GetViewRecordsByFundId_GenAccId(int fundId, int generalLedgerAccId);
    }
}
