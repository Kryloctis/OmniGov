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
        DataTable GetBudgetRealignmentByAppropriationId(int budgetAppropriationsId);
        DataTable GetRecordsByRealignmentId(int realignmentId);
        DataTable GetRealignedAccountsByBudgetAppropriationId(int budgetAppropriationsId);
        DataTable GetRealignedAccountsByRealignmentId(int realignmentId);



        Dictionary<string, string> GetRecordByRealignmentId(int realignmentId);

        Decimal GetAmountOfBudgetRealignedToByBudgetId(int budgetId);
        Decimal GetAmountOfBudgetRealignedFromByBudgetId(int budgetId);
        bool InsertRealignment(BudgetRealignmentModel entity);
        bool BudgetHasRealignment(int budgetId);
        ushort GetLastInsertedID();        
        bool RemoveRealignmentAccounts(int realignmentId);
    }
}
