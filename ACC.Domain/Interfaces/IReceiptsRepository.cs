using System;
using System.Collections.Generic;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IReceiptsRepository:IRepository<ReceiptsModel>
    {
        bool UpdateCurrentIssued(ReceiptsModel entity);
        bool ReceiptExist(int accid, int from, int to);
        bool ReceiptConsumed(int id);
    }
}
