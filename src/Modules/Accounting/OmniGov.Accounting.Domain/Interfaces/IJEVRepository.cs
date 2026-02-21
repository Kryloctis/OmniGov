using OmniGov.Accounting.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;
using System.Data;

namespace OmniGov.Accounting.Domain.Interfaces
{
    public interface IJevRepository : IRepository<JevModel>
    {
        bool InsertGeneralJournalEntry(JevModel entity, List<JEVAccountsModel> jevAccountsModelList, GeneralJournalModel generalJournalModel);

        bool InsertCashDisbursementsJournalEntry(JevModel entity, List<JEVAccountsModel> jevAccountsModelList, CashDisbursementsJournalModel cashDisbursementsJournalModel);

        bool InsertCheckDisbursementsJournalEntry(JevModel entity, List<JEVAccountsModel> jevAccountsModelList, CheckDisbursementsJournalModel checkDisbursementsJournalModel);

        bool InsertCashReceiptsJournalEntry(JevModel entity, List<JEVAccountsModel> jevAccountsModelList, CashReceiptsJournalModel cashReceiptsJournalModel);

        bool InsertProcurementReceivedJournalEntry(JevModel entity, List<JEVAccountsModel> jevAccountsModels);

        bool InsertADADisbursementsJournalEntry(JevModel entity, List<JEVAccountsModel> jevAccountsModelList, ADADisbursementsJournalModel aDADisbursementsJournalModel);

        bool UpdateGeneralJournalEntry(JevModel entity, (int jrnlId, string jrnlName) prevJournal, List<JEVAccountsModel> jevAccountsModelList, GeneralJournalModel generalJournalModel);

        bool UpdateCashDisbursementsJournalEntry(JevModel entity, (int jrnlId, string jrnlName) prevJournal, List<JEVAccountsModel> jevAccountsModelList, CashDisbursementsJournalModel cashDisbursementsJournalModel);

        bool UpdateCheckDisbursementsJournalEntry(JevModel entity, (int jrnlId, string jrnlName) prevJournal, List<JEVAccountsModel> jevAccountsModelList, CheckDisbursementsJournalModel checkDisbursementsJournalModel);

        bool UpdateCashReceiptsJournalEntry(JevModel entity, (int jrnlId, string jrnlName) prevJournal, List<JEVAccountsModel> jevAccountsModelList, CashReceiptsJournalModel cashReceiptsJournalModel);

        bool UpdateProcurementReceivedJournalEntry(JevModel entity, (int jrnlId, string jrnlName) prevJournal, List<JEVAccountsModel> jevAccountsModels);

        bool UpdateADADisbursementsJournalEntry(JevModel entity, (int jrnlId, string jrnlName) prevJournal, List<JEVAccountsModel> jevAccountsModelList, ADADisbursementsJournalModel aDADisbursementsJournalModel);

        bool Delete(JevModel entity);

        bool DeletePrevJournals(int jevId, string journalName);

        int GetLastInsertedID();

        string GetLastTransactionNo(int year);

        string GetLastJevNoSeries(int fundId);

        Dictionary<string, string> GetViewRecordByJEVId(int jevId);

        DataTable GetRecordsByJevNoAndDate(string searchText, sbyte jevDate, ushort year, byte journalId);

        int JevCounterByJournal(string fundName, int year, string journalName);

        int GetJevCount(JevModel.Status? status, string journalName, string fundName, short year);

        bool SetJevStatus(int id, JevModel.Status status, string remarks);

        DataTable GetViewRecords(string status, string searchTxt, string journalName, string fundName, short year);

        DataTable GetViewRecords(JevModel.Status status);
    }
}