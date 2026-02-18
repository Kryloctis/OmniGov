using OmniGov.Core.Interfaces.Repositories;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IPaymentFeesCharges : IRepository<PaymentFeesChargesModel>
    {
        bool InsertBulk(List<PaymentFeesChargesModel> entityList);
    }
}