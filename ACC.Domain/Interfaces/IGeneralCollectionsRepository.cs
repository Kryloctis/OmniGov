using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IGeneralCollectionsRepository : IRepository<GeneralCollectionsModel>
    {
        bool CodeExist(string id);
        Dictionary<string, string> GetRecordByID(string Id);
        decimal SumRecords(int id);
        DataTable GetRecordByData(string Id);
        DataTable GetRecordByGC(string Id);
        DataTable GetRecordByForms(int Id);
        DataTable GetRecordByCollections(int Id);
        DataTable GetRecordByDeposits(int Id);
        DataTable GetRecordByGC(string from, string to);
        DataTable GetRecordByReceipts(int Id); 
        DataTable GetRecordByReceiptsConsolidated(string to);
    }
}
