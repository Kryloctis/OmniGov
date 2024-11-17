using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IPaymentCollectionHasChequesRepository : IAccRepository<PaymentCollectionHasChequesModel>
    {
        bool InsertWithCheques(PaymentCollectionHasChequesModel entity);
    }
}