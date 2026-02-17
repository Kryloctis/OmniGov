using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IPaymentCollectionsRepository : IRepository<PaymentCollectionsModel>
    {
        DataTable GerViewRecordsByCoIdAccFormId(int coId, int accFormId, string searchKey, int rowFilter);

        DataTable GerViewRecordsByJoIdAccFormId(int joId, int accFormId, string searchKey, int rowFilter);

        List<int> GetRecordsReceiptsByAccFormId(int accountableFormId);

        DataTable GetRecordByLedger(object[] parameter);

        DataTable GetCollectionsPerCollector();

        int GetTotalUsedAccountableFormByCollectingOfficerID(int collectingOfficerID, int accountableFormID);

        bool ReceiptExist(int receipt, int formid);

        bool ReceiptAlreadyUsed(int accountableFormID, int receiptNumberFrom);

        int GetLastInsertedID(int createdById);

        bool InsertWithFeesCharges(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, List<PaymentFeesChargesModel> paymentFeesChargesModels);

        bool InsertWithRptPayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, RptPaymentsModel rptPaymentsModel, List<RptTaxDuesModel> rptTaxDuesModels);

        bool InsertWithMarriageLicensePayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, MarriageLicenseModel marriageLicenseModel, List<PaymentFeesChargesModel> paymentFeesChargesModels);

        bool InsertWithBurialPermitPayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, BurialPermitModel burialPermitModel, List<PaymentFeesChargesModel> paymentFeesChargesModels);

        bool InsertWithCattleOwnershipPayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, CattleOwnershipModel cattleOwnershipModel, List<PaymentFeesChargesModel> paymentFeesChargesModels);

        bool InsertWithPrevCattleOwnership(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, CattleOwnershipModel cattleOwnershipModel, PrevCattleOwnershipModel prevCattleOwnershipModel, List<PaymentFeesChargesModel> paymentFeesChargesModels);

        bool InsertWithBiddingPayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, TaxpayersModel taxpayersModel, BidModel bidModel, BiddersModel biddersModel);

        public DataTable GetViewConsolidatedRcdRecords(DateTime date, UsersModel createdBy);

        public DataTable GetViewConsolidatedRcdRecords(RcdCollectionsModel rcdCollectionsModel);

        List<RcdCollectionsModel> GetRcdCollections(DateTime date, UsersModel createdBy);

        List<RcdCollectionsModel> GetRcdCollections(RcdModel rcdModel);

        bool VoidPayment(PaymentCollectionsModel paymentCollectionModel);

        bool InsertWithCommunityTaxCertificate(PaymentCollectionsModel paymentCollectionsModel, CommunityTaxCertificateModel communityTaxCertificateModel);
    }
}
