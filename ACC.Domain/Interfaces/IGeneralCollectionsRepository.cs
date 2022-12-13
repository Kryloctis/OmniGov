using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IGeneralCollectionsRepository : IAccRepository<GeneralCollectionsModel>
    {
        bool CodeExist(string id);

        Dictionary<string, string> GetRecordByID(string Id);

        decimal SumRecords(int id);

        DataTable GetRecordByData(string Id);

        DataTable GetRecordByGC(string Id);

        DataTable GetRecordByForms(int Id);

        DataTable GetRecordByCollections(int Id);

        DataTable GetRecordByDeposits(int Id);

        DataTable GetRecordOfGeneralCollectionByDateRange(string from, string to);

        DataTable GetRecordByReceipts(int Id);

        DataTable GetRecordsByFundId(int fundId);

        DataTable GetRecordsByFundIdAndSearchKey(int fundId, string searchKey);

        DataTable GetRecordsOfConsolidatedReceiptsByEndingDate(string to);

        DataTable GetRecordsByRCDNo(string rcdNo);

        int GetGeneralCollectionId(string rcdNo);

        int GetRCDCount();
    }
}