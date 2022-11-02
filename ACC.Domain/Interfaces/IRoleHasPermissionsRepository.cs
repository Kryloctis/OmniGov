using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IRoleHasPermissionsRepository : IAccRepository<RoleHasPermissionsModel>
    {
        DataTable GetRecordsByRoleId(byte roleId);

        bool DeleteByRoleId(byte roleId);
    }
}
