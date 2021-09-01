using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IJEVRepository : IRepository<JEVModel>
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

        string GetLastJevNoSeries();

        Dictionary<string, string> GetRecordByJEV(string jevNo);

        DataTable GetRecordsByJEVNoAndDate(string searchText, sbyte jevDate);

        bool JevNumberAndYearExist(string jevNo, int jevEntryDate);

        bool JevNumberExist(string jevNo, int jevId);

        int JevCounter(byte journalId);

        int TotalApproveJEV();
        int TotalPendingJEV();
        int TotalDisapprovedJEV();
        int TotalCancelledJEV();

        bool SetJEVStatus(int jevId, byte jevStatus);

        //REMARKS
        bool SetRemarks(int jevId, string remarks);
        string GetRemarks(int jevId);


        DataTable FilterRecords(byte jevStatus, string searchTxt, short month, short year);

        byte GetJevStatus(int jevId);

        //SFPs
        decimal GetSumByMajorAccountGroup(int fundId, int majorAccountGroupId, byte isDebit, DateTime dateEntry);

        decimal GetSumPreviousYearTransactionsByFundIdAndMajAccountGroupId(int fundId, int majorAccountGroupId, byte isDebit, DateTime dateEntry);
    }
}
