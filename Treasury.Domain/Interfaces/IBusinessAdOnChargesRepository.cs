using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IBusinessAdOnChargesRepository : IRepository<BusinessAddOnChargesModel>
    {
        bool DescriptionExist(string name);

        bool DescriptionExist(int id, string name);
    }
}
