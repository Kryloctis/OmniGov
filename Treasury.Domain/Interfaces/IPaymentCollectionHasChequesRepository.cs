using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IPaymentCollectionHasChequesRepository : IRepository<PaymentCollectionHasChequesModel>
    {
        bool InsertWithCheques(PaymentCollectionHasChequesModel entity);
    }
}
