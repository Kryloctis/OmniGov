using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IRCIRepository:IRepository<RCIModel>
    {
        DataTable GetRecordsbyaccountid(int Id,string month);
        DataTable GetRecords(int id);
    }
}
