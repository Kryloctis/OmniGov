using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRoleHasPermissionsRepository : IAccRepository<RoleHasPermissionsModel>
    {
        DataTable GetRecordsByRoleId(byte roleId);

        DataTable GetViewRecordsByRoleId(byte roleId, string office);

        bool DeleteByRoleId(byte roleId);
    }
}