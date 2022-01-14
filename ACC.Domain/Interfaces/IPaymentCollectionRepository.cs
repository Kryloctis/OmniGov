using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IPaymentCollectionRepository : IRepository<PaymentCollectionModel>
    {
        DataTable GetRecordByLedger(string month);
        DataTable GetRecordByExcel(string month);
        DataTable GetRecordsBySearch(string searchText);
        DataTable GetRecordByLedger(int Id, string month);
        DataTable GetRecordByLedger(int Id, int fid, string from,string to);
        DataTable GetRecordsByCollectingOfficerId(int collectorId);
        decimal SumRecords();
        decimal SumRecords(int Id, string month);
        decimal SumRecords(int Id,int fid,string from,string to);
        decimal SumRecords(int Id, int fid, string from, string to, string ids);
        DataTable GetRecordByLedger(object[] parameter);
        DataTable GetRecordsByDate(string date);
        bool ReceiptExist(string receipt, int formid);
    }
}
