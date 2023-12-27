using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IPaymentCollectionsRepository : IAccRepository<PaymentCollectionsModel>
    {
        List<int> GetRecordsReceiptsByAccFormId(int accountableFormId);

        DataTable GetRecordsByCollectingOfficerId(int collectorId);

        DataTable GetRecordsByUserId(int userId);

        DataTable GetRecordByLedger(object[] parameter);

        DataTable GetRecordsByDate(string date);

        DataTable FilterRecords(string date, int collectingOfficerID, bool collectingOfficerJO, string searchKey);

        DataTable GetCollectionsPerCollector();

        int GetPreviouslyUsedReceiptNumber(int collectingOfficerID, int accountableFormID);

        int GetTotalUsedAccountableFormByCollectingOfficerID(int collectingOfficerID, int accountableFormID);

        bool ReceiptExist(int receipt, int formid);

        bool ReceiptExist(int paymentCollectionId, int receipt, int formid);

        bool ReceiptAlreadyUsed(int accountableFormID, int receiptNumberFrom);

        int GetLastInsertedID(int createdById);

        bool InsertWithFeesCharges(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, List<PaymentFeesChargesModel> paymentFeesChargesModels);

        bool InsertWithRptPayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, RptPaymentsModel rptPaymentsModel, List<RptTaxDuesModel> rptTaxDuesModels);

        bool InsertWithMarriageLicensePayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, MarriageLicenseModel marriageLicenseModel, List<PaymentFeesChargesModel> paymentFeesChargesModels);

        bool InsertWithBurialPermitPayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, BurialPermitModel burialPermitModel, List<PaymentFeesChargesModel> paymentFeesChargesModels);

        bool InsertWithCattleOwnershipPayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, CattleOwnershipModel cattleOwnershipModel, List<PaymentFeesChargesModel> paymentFeesChargesModels);
    }
}