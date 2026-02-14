using Budget.Domain.Models;
using OmniGov.Core.Interfaces;

namespace Budget.Domain.Interfaces
{
    public interface IObligationAccountRepository : IRepository<ObligationAccountModel>
    {
        bool DeleteByOblgtnId(int ObligationRequestId);
    }
}