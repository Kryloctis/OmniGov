using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IReceiptsRepository:IRepository<ReceiptsModel>
    {
        bool ReceiptExist(int accid, int from, int to);
        bool ReceiptConsumed(int id);
        DataTable NextReceipt(int id);
        DataTable FirstReceipt(int id);
        bool ReceiptsIssued(int id);
    }
}
