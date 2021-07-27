using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IBeginningBalancesRepository : IRepository<BeginningBalancesModel>
    {
        Dictionary<string, string> GetRecordByFundsAndGeneralLedgerID(byte fundsId, ushort generalLedgerId, short year);

        Dictionary<string, string> GetRecordByFundsAndGeneralLedgerID(byte fundsId, ushort generalLedgerId, short year, ushort? subsidiaryLedgerId = null);

        decimal GetSumBalanceByGeneralLedgerId(byte fundsId, ushort generalLedgerId, short year);


        #region CHART OF ACCOUNTS

        decimal GetSumBalances(byte fundsId, ushort generalLedgerId, short year, byte isDebit);

        #endregion

        decimal GetSumBalanceByGeneralLedgerId(byte fundsId, ushort generalLedgerId, short year, ushort? subsidiaryLedgerId = null);

        bool GeneralLedgerBalanceExist(byte fundsId, ushort generalLedgerId, short year);

        bool SubsidiaryLedgerBalanceExist(byte fundsId, ushort generalLedgerId, short year, ushort subsidiaryLedgerId);

        Dictionary<string, string> GetDebitAndCreditOfTemporaryAccounts(byte fundsId);

        Dictionary<string, string> GetDebitAndCreditOfPermanentAccounts(byte fundsId);

        decimal GetDebitSumOfSubsidiaryLedger(byte fundsId, ushort generalLedgerId, short year);

        decimal GetCreditSumOfSubsidiaryLedger(byte fundsId, ushort generalLedgerId, short year);

        
        decimal GetGovernmentEquityBalance(byte fundsId, ushort generalLedgerId, short year);
    }
}
