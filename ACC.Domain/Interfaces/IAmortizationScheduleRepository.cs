using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IAmortizationScheduleRepository:IAccRepository<AmortizationScheduleModel>
    {
        DataTable GetRecordsByAmortizationId(int amortizationId);

        bool dateExist(DateTime date);
    }
}
