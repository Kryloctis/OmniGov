using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IObligationRequestRepository : IRepository<ObligationRequestModel>
    {
        bool ObligationRequestNoExist(string obligationNo);

        bool ObligationRequestNoExist(int Id, string obligationNo);

        decimal TotalObligationRequestByYear(int fundsId, int fppId, int? otherFPPId, int allotmentClassId, int accountId, short year);

        int GetLastInsertedID();

        bool Insert(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels);
    }
}
