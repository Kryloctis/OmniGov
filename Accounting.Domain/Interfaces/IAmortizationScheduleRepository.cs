using Accounting.Domain.Entities;
using OmniGov.Core.Interfaces;
using System.Data;

namespace Accounting.Domain.Interfaces
{
    public interface IAmortizationScheduleRepository : IRepository<AmortizationScheduleModel>
    {
        DataTable GetRecordsByAmortizationId(int amortizationId);
    }
}