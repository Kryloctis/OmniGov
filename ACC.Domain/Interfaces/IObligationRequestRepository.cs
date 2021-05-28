using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IObligationRequestRepository : IRepository<ObligationRequestModel>
    {
        bool ObligationRequestNoExist(string obligationNo);

        bool ObligationRequestNoExist(int Id, string obligationNo);

        decimal TotalObligationRequestByYear(int fundsId, int fppId, int? otherFPPId, int allotmentClassId, int accountId, short year);

        decimal TotalObligationRequestByDateYear(int fundId, int fppId, int? otherFPPId, int allotmentClassId, int accountId, DateTime dateRequested, short year);

        int GetLastInsertedID();

        bool Insert(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels);

        bool Update(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels);

        bool Delete(int obligationRequestId);

        Dictionary<string, string> GetViewRecordByObligationNo(string obligationNo);

        DataTable GetViewRecordsById(int Id);


        //Dashboard
        decimal GetTotalObligationsByIds(int fundId, int allotmentClassId, int fppId);

    }
}
