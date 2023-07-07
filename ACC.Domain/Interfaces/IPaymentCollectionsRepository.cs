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

        int GetLastInsertedID();

        bool InsertWithGeneralPayment(PaymentCollectionsModel paymentCollectionModel, GeneralPaymentsModel generalPaymentModel);

        bool InsertWithRptPayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, RptPaymentsModel rptPaymentsModel, List<RptTaxDuesModel> rptTaxDuesModels);

        bool InsertWithMarriageLicensePayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, MarriageLicenseModel marriageLicenseModel);

        bool InsertWithBurialPermitPayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, BurialPermitModel burialPermitModel);
        bool InsertWithCattleOwnershipPayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, CattleOwnershipModel cattleOwnershipModel);
        bool InsertWithTransferOfCattleOwnershipPayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, CattleTransferOfOwnershipModel cattleTransferOfOwnershipModel);
        bool ReceiptAlreadyUsed(int accountableFormID, int receiptNumberFrom);
    }
}