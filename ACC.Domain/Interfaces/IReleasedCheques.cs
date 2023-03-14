using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IReleasedCheques : IAccRepository<ReleasedChequesModel>
    {
        DataTable GetViewRecords();
        DataTable GetViewRecords(int bankAccountID, int fundsID, string txtSeach);
        DataTable GetViewRecordsByBankAccountID(int bankAccountIDID);
        DataTable GetViewRecordsByBankAccountIDAndPeriodCovered(int bankAccountID, string periodCovered);
    }
}
