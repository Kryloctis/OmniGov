using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface ISubsidiaryLedgerAccountsRepository : IRepository<SubsidiaryLedgerAccountsModel>
    {
        DataTable GetRecordsByReference(int Id);
        DataTable GetRecordsBySearchByReference(string srchtxt, int Id);
        DataTable GetRecordsByFundAndGeneralLedger(byte fundId, ushort generalLedgerId);
        bool HasSubsidiary(ushort generalLedgerId);
    }
}
