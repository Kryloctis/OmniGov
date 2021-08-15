using ACC.Domain.Models;
using System;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IBeginningBalancesRepository : IRepository<BeginningBalancesModel>
    {
        Dictionary<string, string> GetRecordByFundsAndGeneralLedgerID(byte fundsId, ushort generalLedgerId, short year, ushort? subsidiaryLedgerId = null);

        decimal GetSumBalances(byte fundsId, ushort generalLedgerId, short year, byte isDebit, ushort? subsidiaryLedgerId = null);

        Dictionary<string, decimal> GetSumBalances(byte fundsId, ushort generalLedgerId, DateTime dateEntry, ushort? subsidiaryLedgerId = null);

        Dictionary<string, decimal> GetSumBalancesByAccountGroup(byte fundsId, ushort accountGroupId, DateTime dateEntry, ushort? subsidiaryLedgerId = null);

        bool DeleteById(int Id);

        decimal GetSumBalanceByGeneralLedgerId(byte fundsId, ushort generalLedgerId, short year, ushort? subsidiaryLedgerId = null);

        bool GeneralLedgerBalanceExist(byte fundsId, ushort generalLedgerId, short year);

        bool SubsidiaryLedgerBalanceExist(byte fundsId, ushort generalLedgerId, short year, ushort subsidiaryLedgerId);

    }
}
