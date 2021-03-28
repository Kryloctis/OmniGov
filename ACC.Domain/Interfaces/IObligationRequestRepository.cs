using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IObligationRequestRepository : IRepository<ObligationRequestModel>
    {
        bool ObligationNumExist(string obligationNum);
        bool ObligationNumExist(int id, string obligationNum);
    }
}
