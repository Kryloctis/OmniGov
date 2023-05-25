using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ISubsidiaryLedgerAccountsRepository : IAccRepository<SubsidiaryLedgerAccountsModel>
    {
        DataTable GetRecordsByReference(int Id);

        DataTable GetRecordsBySearchByReference(string srchtxt, int Id);

        DataTable GetRecordsByFundAndGeneralLedger(byte fundId, ushort generalLedgerId);

        bool HasSubsidiary(ushort generalLedgerId, byte fundId);

        DataTable GetViewRecordsByFundId_GenAccId(int fundId, int generalLedgerAccId);
    }
}