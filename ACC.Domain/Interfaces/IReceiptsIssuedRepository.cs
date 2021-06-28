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
        bool HasIssued(int id);
        DataTable GetRecords(int id);
        DataTable GetRecords(string coid, string formid);
        DataTable GetRecordsReceipts(string id);
    }
}
