using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IMajorAccountGroupRepository : IRepository<MajorAccountGroupModel>
    {
        DataTable GetViewRecords();
        DataTable GetRecordsByAccountGroupId(byte id);
    }
}
