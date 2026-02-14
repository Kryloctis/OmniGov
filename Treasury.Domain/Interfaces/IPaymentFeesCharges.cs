using OmniGov.Core.Interfaces;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IPaymentFeesCharges : IRepository<PaymentFeesChargesModel>
    {
        bool InsertBulk(List<PaymentFeesChargesModel> entityList);
    }
}