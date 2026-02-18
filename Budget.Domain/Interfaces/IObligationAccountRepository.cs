using Budget.Domain.Models;
using OmniGov.Core.Interfaces.Repositories;

namespace Budget.Domain.Interfaces
{
    public interface IObligationAccountRepository : IRepository<ObligationAccountModel>
    {
        bool DeleteByOblgtnId(int ObligationRequestId);
    }
}
