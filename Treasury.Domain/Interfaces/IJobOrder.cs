using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IJobOrder : IRepository<JobOrderModel>
    {
        bool IsUserJobOrder(int userId);

        int GetJobOrderIdByUserId(int userId);

        Dictionary<string, string> GetRecordByUserID(int Id);
    }
}
