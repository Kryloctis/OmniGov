using System.Collections.Generic;
using System.Data;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IPaymentCollectionsRepository : IRepository<PaymentCollectionsModel>
    {
        DataTable GetRecordsByCollectingOfficerId(int collectorId);
        DataTable GetRecordsByUserId(int userId);
        DataTable GetRecordByLedger(object[] parameter);
        DataTable GetRecordsByDate(string date);
        DataTable GetRecordsByFilter(string date, int collectorId, string searchKey);
        DataTable GetCollectionsPerCollector();

        int GetPreviouslyUsedReceiptNumber(int collectingOfficerID, int accountableFormID);

        bool ReceiptExist(string receipt, int formid);
        bool ReceiptExist(int paymentCollectionId, string receipt, int formid);
        int GetLastInsertedID();
        bool InsertWithGeneralPayment(PaymentCollectionsModel paymentCollectionModel, GeneralPaymentsModel generalPaymentModel);
        bool InsertWithPaymentPosts(PaymentCollectionsModel paymentCollectionsModel, RptPaymentPostsModel rptPaymentPostsModel, List<RptTaxDuesModel> rptTaxDuesModels);
    }
}
