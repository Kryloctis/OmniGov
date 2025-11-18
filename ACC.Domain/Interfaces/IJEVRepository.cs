using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IJEVRepository : IAccRepository<JevModel>
    {
        bool InsertJevGenJrnl(JevModel entity, List<JEVAccountsModel> jevAccountsModelList, GeneralJournalModel generalJournalModel);

        bool InsertJevCashDsbrsmntsJrnl(JevModel entity, List<JEVAccountsModel> jevAccountsModelList, CashDisbursementsJournalModel cashDisbursementsJournalModel);

        bool InsertJevChkDsbrsmntJrnl(JevModel entity, List<JEVAccountsModel> jevAccountsModelList, CheckDisbursementsJournalModel checkDisbursementsJournalModel);

        bool InsertJevCashRcptsJrnl(JevModel entity, List<JEVAccountsModel> jevAccountsModelList, CashReceiptsJournalModel cashReceiptsJournalModel);

        bool InsertJevProcRcvJrnl(JevModel entity, List<JEVAccountsModel> jevAccountsModels);

        bool InsertJevAdaDsbrsmntsJrnl(JevModel entity, List<JEVAccountsModel> jevAccountsModelList, ADADisbursementsJournalModel aDADisbursementsJournalModel);

        bool UpdateJevGenJrnl(JevModel entity, (int jrnlId, string jrnlName) prevJournal, List<JEVAccountsModel> jevAccountsModelList, GeneralJournalModel generalJournalModel);

        bool UpdateJevCshDsbrsmntsJrnl(JevModel entity, (int jrnlId, string jrnlName) prevJournal, List<JEVAccountsModel> jevAccountsModelList, CashDisbursementsJournalModel cashDisbursementsJournalModel);

        bool UpdateJevChkDsbrsmntJrnl(JevModel entity, (int jrnlId, string jrnlName) prevJournal, List<JEVAccountsModel> jevAccountsModelList, CheckDisbursementsJournalModel checkDisbursementsJournalModel);

        bool UpdateJevCshRcptsJrnl(JevModel entity, (int jrnlId, string jrnlName) prevJournal, List<JEVAccountsModel> jevAccountsModelList, CashReceiptsJournalModel cashReceiptsJournalModel);

        bool UpdateJevProcRcvJrnl(JevModel entity, (int jrnlId, string jrnlName) prevJournal, List<JEVAccountsModel> jevAccountsModels);

        bool UpdateJevAdaDsbrsmntsJrnl(JevModel entity, (int jrnlId, string jrnlName) prevJournal, List<JEVAccountsModel> jevAccountsModelList, ADADisbursementsJournalModel aDADisbursementsJournalModel);

        bool Delete(JevModel entity);
        bool DeletePrevJournals(int jevId, string journalName);
        int GetLastInsertedID();

        string GetLastJevNoSeries(int fundId);

        Dictionary<string, string> GetViewRecordByJEVId(int jevId);

        DataTable GetRecordsByJEVNoAndDate(string searchText, sbyte jevDate, ushort year, byte journalId);

        #region Validations

        bool JevNumberExistBy_JevNo_FundId_Year(string jevNo, int fundId, int year);

        bool JevNumberExistBy_JevId_JevNo_FundId_Year(int jevId, string jevNo, int fundId, int year);

        #endregion Validations

        int JevCounterByJournal(string fundName, int year, string journalName);

        int GetJevCount(string status, string journalName, string fundName, short year);

        int TotalApproveJEV(short month, short year);

        int TotalPendingJEV(short month, short year);

        int TotalDisapprovedJEV(short month, short year);

        int TotalCancelledJEV(short month, short year);

        bool CancelJev(int jevId);

        bool ApproveJev(int jevId);

        bool DisapproveJev(int jevId);

        string GetRemarks(int jevId);

        DataTable GetViewRecords(string jevStatus, string searchTxt, string journalName, string fundName, short year);

        string GetJevStatus(int jevId);

        //SFPs
        decimal GetSumByMajorAccountGroup(int fundId, int majorAccountGroupId, byte isDebit, DateTime dateEntry);

        decimal GetSumPreviousYearTransactionsByFundIdAndMajAccountGroupId(int fundId, int majorAccountGroupId, byte isDebit, DateTime dateEntry);
    }
}