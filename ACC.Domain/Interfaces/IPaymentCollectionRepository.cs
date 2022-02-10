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
        DataTable GetRecordsByFilter(string date, int collectorId, string searchKey);
        bool ReceiptExist(string receipt, int formid);
        bool ReceiptExist(int paymentCollectionId, string receipt, int formid);
    }
}
