using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IBusinessAdOnChargesRepository : IAccRepository<BusinessAddOnChargesModel>
    {
        bool DescriptionExist(string name);

        bool DescriptionExist(int id, string name);
    }
}