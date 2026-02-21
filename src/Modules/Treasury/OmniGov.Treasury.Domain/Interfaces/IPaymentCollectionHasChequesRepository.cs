using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IPaymentCollectionHasChequesRepository : IRepository<PaymentCollectionHasChequesModel>
    {
        bool InsertWithCheques(PaymentCollectionHasChequesModel entity);
    }
}
