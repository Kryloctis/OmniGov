using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IRolesRepository : IRepository<RolesModel>
    {
        DataTable GetRecordsByOffice(string office);

        bool NameExist(string name, string office);
        bool NameExist(string name, string office, int id);
    }
}
