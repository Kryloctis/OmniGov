using OmniGov.Core.Interfaces.Repositories;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IPaymentCollectionHasChequesRepository : IRepository<PaymentCollectionHasChequesModel>
    {
        bool InsertWithCheques(PaymentCollectionHasChequesModel entity);
    }
}