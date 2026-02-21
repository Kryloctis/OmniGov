using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IBusinessAdOnChargesRepository : IRepository<BusinessAddOnChargesModel>
    {
        bool DescriptionExist(string name);

        bool DescriptionExist(int id, string name);
    }
}
