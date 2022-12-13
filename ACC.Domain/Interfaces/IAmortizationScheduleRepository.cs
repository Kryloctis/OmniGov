using ACC.Domain.Models;
using System;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IAmortizationScheduleRepository : IAccRepository<AmortizationScheduleModel>
    {
        DataTable GetRecordsByAmortizationId(int amortizationId);

        bool dateExist(DateTime date);
    }
}