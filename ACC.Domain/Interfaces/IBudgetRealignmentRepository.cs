using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IBudgetRealignmentRepository : IRepository<BudgetRealignmentModel>
    {

        DataTable GetRecordsByBudgetAppropriationId(int budgetAppropriationsId);
        DataTable GetRealignmentFromByAppropriationId(int budgetAppropriationsId);
        DataTable GetRealignmentToByAppropriationId(int budgetAppropriationsId);
        Decimal GetAmountOfBudgetRealignedToByBudgetId(int budgetId);
        Decimal GetAmountOfBudgetRealignedFromByBudgetId(int budgetId);
        bool InsertRealignment(BudgetRealignmentModel entity);
        ushort GetLastInsertedID();
    }
}
