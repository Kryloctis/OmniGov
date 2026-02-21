using OmniGov.Accounting.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;
using System.Data;

namespace OmniGov.Accounting.Domain.Interfaces
{
    public interface IAmortizationScheduleRepository : IRepository<AmortizationScheduleModel>
    {
        DataTable GetRecordsByAmortizationId(int amortizationId);
    }
}
