using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IPaymentFeesCharges : IRepository<PaymentFeesChargesModel>
    {
        bool InsertBulk(List<PaymentFeesChargesModel> entityList);
    }
}
