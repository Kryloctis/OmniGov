using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IObligationRequestRepository : IRepository<ObligationRequestModel>
    {
        Dictionary<string, string> GetRecordByObligationNum(string obligationNum); 

        bool ObligationNumExist(string obligationNum);
        bool ObligationNumExist(int id, string obligationNum);
    }
}
