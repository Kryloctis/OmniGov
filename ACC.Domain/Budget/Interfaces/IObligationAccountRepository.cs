using ACC.Domain.Budget.Models;
using ACC.Domain.Interfaces;
using System.Data;

namespace ACC.Domain.Budget.Interfaces
{
    public interface IObligationAccountRepository : IAccRepository<ObligationAccountModel>
    {
        bool DeleteByOblgtnId(int ObligationRequestId);
    }
}