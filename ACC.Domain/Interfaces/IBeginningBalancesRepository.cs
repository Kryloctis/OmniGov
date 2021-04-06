using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IBeginningBalancesRepository : IRepository<BeginningBalancesModel>
    {
        Dictionary<string, string> GetRecordByGeneralLedgerAndFundsID(byte fundsId, ushort generalLedgerId, short year);
        decimal GetSumBalanceByGeneralLedgerId(byte fundsId, ushort generalLedgerId, short year);

        Dictionary<string, string> GetRecordByGeneralLedgerAndFundsID(byte fundsId, ushort generalLedgerId, short year, ushort? subsidiaryLedgerId = null);
        decimal GetSumBalanceByGeneralLedgerId(byte fundsId, ushort generalLedgerId, short year, ushort? subsidiaryLedgerId = null);
        bool GeneralLedgerBalanceExist(byte fundsId, ushort generalLedgerId, short year);

        bool SubsidiaryLedgerBalanceExist(byte fundsId, ushort generalLedgerId, short year, ushort subsidiaryLedgerId);
    }
}
