using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IReceiptsIssuedRepository : IRepository<ReceiptsIssuedModel>
    {
        bool IssuedExist(int coid, int id);
        bool UpdateReturnedReceipt(ReceiptsIssuedModel entity);
        bool HasIssued(int accountableFormId, int collectorId);
        bool UpdateCurrentIssued(ReceiptsIssuedModel entity);
        bool IssuedExist(ReceiptsIssuedModel entity);
        DataTable GetRecords(int id);
        DataTable GetRecords(string coid, string formid);
        DataTable GetRecordsReceipts(string collectorId);
        DataTable GetAccountabilityForAccountableForms(string reportNumber);

        DataTable GetReturnedReceipts();

        DataTable GetReturnedReceiptsBySearch(string searchKey);
    }
}
