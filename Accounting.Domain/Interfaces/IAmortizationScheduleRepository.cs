using Accounting.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using System.Data;

namespace Accounting.Domain.Interfaces
{
    public interface IAmortizationScheduleRepository : IRepository<AmortizationScheduleModel>
    {
        DataTable GetRecordsByAmortizationId(int amortizationId);
    }
}
