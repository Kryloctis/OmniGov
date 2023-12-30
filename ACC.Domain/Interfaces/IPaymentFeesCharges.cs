using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IPaymentFeesCharges : IAccRepository<PaymentFeesChargesModel>
    {
        bool InsertBulk(List<PaymentFeesChargesModel> entityList);
    }
}