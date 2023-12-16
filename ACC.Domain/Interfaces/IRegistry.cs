using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACC.Domain.Interfaces
{
    public interface IRegistry : IAccRepository<RegistryModel>
    {
        DataTable GetRecordsBySearh_Limit(string searchKey, int limitCount);
    }
}