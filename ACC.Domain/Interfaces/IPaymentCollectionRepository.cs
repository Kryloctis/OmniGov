using System.Data;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IPaymentCollectionRepository : IRepository<PaymentCollectionModel>
    {
        DataTable GetRecordsByCollectingOfficerId(int collectorId);
        DataTable GetRecordsByUserId(int userId);
        DataTable GetRecordByLedger(object[] parameter);
        DataTable GetRecordsByDate(string date);
        DataTable FilterRecords(string date, int collectorId, string searchKey);
        DataTable GetCollectionsPerCollector();

        int GetPreviouslyUsedReceiptNumber(int collectingOfficerID, int accountableFormID);

        bool ReceiptExist(string receipt, int formid);
        bool ReceiptExist(int paymentCollectionId, string receipt, int formid);
        int GetLastInsertedID();
        bool InsertWithGeneralPayment(PaymentCollectionModel paymentCollectionModel, GeneralPaymentsModel generalPaymentModel);
    }
}
