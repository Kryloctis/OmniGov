using ACC.Domain.Models;
using System;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IBeginningBalancesRepository : IRepository<BeginningBalancesModel>
    {
        decimal GetSumBalancesBy_FundId_Year_Availablility(int fundsId, short year, bool isDebit);

        decimal GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId(byte fundsId, ushort generalLedgerId, short year, byte isDebit, ushort? subsidiaryLedgerId = null);

        Dictionary<string, string> GetRecordBy_FundId_GenLedgId_Year_SubLedgId(byte fundsId, ushort generalLedgerId, short year, ushort? subsidiaryLedgerId = null);

        Dictionary<string, decimal> GetSumBeginningBalanceBy_FundId_AccGrpId_Date_SubLedgeId(byte fundsId, ushort accountGroupId, DateTime dateEntry, ushort? subsidiaryLedgerId = null);

        Dictionary<string, decimal> GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(byte fundsId, ushort majAccountGroupId, DateTime dateEntry, ushort? subsidiaryLedgerId = null);

        Dictionary<string, decimal> GetSumBalancesBy_FundId_GenLedgId_Date_SubLedgId(byte fundsId, ushort generalLedgerId, DateTime dateEntry, ushort? subsidiaryLedgerId = null);

        bool DeleteById(int Id);

        decimal GetSumBalanceBy_FundId_GenLedgId_Year_SubLedgId(byte fundsId, ushort generalLedgerId, short year, ushort? subsidiaryLedgerId = null);

        bool GeneralLedgerBalanceExist(byte fundsId, ushort generalLedgerId, short year);

        bool SubsidiaryLedgerBalanceExist(byte fundsId, ushort generalLedgerId, short year, ushort subsidiaryLedgerId);

    }
}
