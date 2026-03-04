using OmniGov.Budget.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;

namespace OmniGov.Budget.Domain.Interfaces
{
    public interface IObligationAccountRepository : IRepository<ObligationAccountModel>
    {
        bool DeleteByOblgtnId(int ObligationRequestId);
    }
}
