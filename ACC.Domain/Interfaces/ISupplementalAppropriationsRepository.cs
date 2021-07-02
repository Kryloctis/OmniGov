using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface ISupplementalAppropriationsRepository : IRepository<SupplementalAppropriationsModel>
    {
        DataTable GetRecordsByBudgetAppropriationId(int budgetAppropriationsId);

        DataTable GetRecordsByBudgetAppropriationIdDateEntry(int budgetAppropriationId, DateTime dateEntry);
    }
}
