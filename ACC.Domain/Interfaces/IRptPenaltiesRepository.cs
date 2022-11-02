using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IRptPenaltiesRepository: IAccRepository<RptPenaltiesModel>
    {
        Dictionary<string, string> GetRecordByDescription(string description);
    }
}
