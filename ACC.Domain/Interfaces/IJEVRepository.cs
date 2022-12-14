using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IJEVRepository : IAccRepository<JEVModel>
    {
        bool InsertWithGeneralJournal(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, GeneralJournalModel generalJournalModel);

        bool InsertWithCashDisbursements(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, CashDisbursementsJournalModel cashDisbursementsJournalModel);

        bool UpdateWithCashDisbursements(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, CashDisbursementsJournalModel cashDisbursementsJournalModel);

        bool InsertWithCheckDisbursement(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, CheckDisbursementsJournalModel checkDisbursementsJournalModel);

        bool UpdateWithCheckDisbursement(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, CheckDisbursementsJournalModel checkDisbursementsJournalModel);

        bool InsertWithCashReceipts(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, CashReceiptsJournalModel cashReceiptsJournalModel);

        bool UpdateWithCashReceipts(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, CashReceiptsJournalModel cashReceiptsJournalModel);

        bool InsertWithADADisbursements(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, ADADisbursementsJournalModel aDADisbursementsJournalModel);

        bool UpdateWithADADisbursements(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, ADADisbursementsJournalModel aDADisbursementsJournalModel);

        bool UpdateWithGeneralJournal(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, GeneralJournalModel generalJournalModel);

        bool Insert(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList);

        bool Update(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList);

        bool Delete(JEVModel entity);

        int GetLastInsertedID();

        string GetLastJevNoSeries(int fundId);

        Dictionary<string, string> GetViewRecordByJEVId(int jevId);

        DataTable GetRecordsByJEVNoAndDate(string searchText, sbyte jevDate, ushort year, byte journalId);

        #region Validations

        bool JevNumberExistBy_JevNo_FundId_Year(string jevNo, int fundId, int year);

        bool JevNumberExistBy_JevId_JevNo_FundId_Year(int jevId, string jevNo, int fundId, int year);

        #endregion Validations

        int JevCounterByJournal(string fundName, int month, int year, string journalName);

        int GetJEVCount(string status, string journalName, string fundName, short month, short year);

        int TotalApproveJEV(short month, short year);

        int TotalPendingJEV(short month, short year);

        int TotalDisapprovedJEV(short month, short year);

        int TotalCancelledJEV(short month, short year);

        bool SetJEVStatus(int jevId, string status);

        //REMARKS
        bool SetRemarks(int jevId, string remarks);

        string GetRemarks(int jevId);

        DataTable GetViewRecords_By_Status_JournalName_Search_Month_Year(string jevStatus, string searchTxt, string journalName, string fundName, short month, short year);

        string GetJevStatus(int jevId);

        //SFPs
        decimal GetSumByMajorAccountGroup(int fundId, int majorAccountGroupId, byte isDebit, DateTime dateEntry);

        decimal GetSumPreviousYearTransactionsByFundIdAndMajAccountGroupId(int fundId, int majorAccountGroupId, byte isDebit, DateTime dateEntry);
    }
}