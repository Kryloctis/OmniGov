using OmniGov.Core.Interfaces;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IPaymentCollectionHasChequesRepository : IRepository<PaymentCollectionHasChequesModel>
    {
        bool InsertWithCheques(PaymentCollectionHasChequesModel entity);
    }
}