using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRCIDeductions : IRepository<RCIObligationsModel>
    {
        DataTable GetDeductionsByRCIId(int rciId);
    }
}
