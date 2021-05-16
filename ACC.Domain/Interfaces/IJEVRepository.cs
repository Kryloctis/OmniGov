using System.Collections.Generic;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IJEVRepository : IRepository<JEVModel>
    {
        bool InsertWithCashDisbursements(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, CashDisbursementsJournalModel cashDisbursementsJournalModel);

        bool UpdateWithCashDisbursements(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, CashDisbursementsJournalModel cashDisbursementsJournalModel);

        bool InsertWithCheckDisbursement(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, CheckDisbursementsJournalModel checkDisbursementsJournalModel);

        bool UpdateWithCheckDisbursement(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, CheckDisbursementsJournalModel checkDisbursementsJournalModel);

        bool InsertWithCashReceipts(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, CashReceiptsJournalModel cashReceiptsJournalModel);

        bool UpdateWithCashReceipts(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, CashReceiptsJournalModel cashReceiptsJournalModel);

        bool InsertWithADADisbursements(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, ADADisbursementsJournalModel aDADisbursementsJournalModel);

        bool UpdateWithADADisbursements(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, ADADisbursementsJournalModel aDADisbursementsJournalModel);

        bool Insert(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList);

        bool Update(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList);

        bool Delete(JEVModel entity);

        int GetLastInsertedID();

        Dictionary<string, string> GetRecordByJEV(string jevNo);

        bool JevNumberExist(string jevNo);

        bool JevNumberExist(string jevNo, int jevId);
    }
}
