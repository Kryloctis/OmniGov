using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface ISubMajorAccountGroupRepository : IRepository<SubMajorAccountGroupModel>
    {
        DataTable GetRecordsByMajorAccountId(short majorAccountId);

        DataTable GetViewRecordsByMajorAccountId(short majorAccountId);
    }
}
