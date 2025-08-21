using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRolesPermissionsRepository : IAccRepository<RolesPermissionsModel>
    {
        DataTable GetViewRecordsByRoleId(int roleId);

        bool DeleteByRoleId(int roleId);
    }
}