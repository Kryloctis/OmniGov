using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IObligationAccountRepository : IAccRepository<ObligationAccountModel>
    {
        bool DeleteByObligationRequestId(int ObligationRequestId);
    }
}