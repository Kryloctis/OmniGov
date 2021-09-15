using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IBudgetRealignmentRepository : IRepository<BudgetRealignmentModel>
    {
        DataTable FilterRecords(string searchTxt, short month, short year);
    }
}
