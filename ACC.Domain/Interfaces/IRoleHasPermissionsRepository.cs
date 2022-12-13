using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRoleHasPermissionsRepository : IAccRepository<RoleHasPermissionsModel>
    {
        DataTable GetRecordsByRoleId(byte roleId);

        bool DeleteByRoleId(byte roleId);
    }
}