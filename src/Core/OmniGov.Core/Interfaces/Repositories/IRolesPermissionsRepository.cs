using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces.Repositories
{
    public interface IRolesPermissionsRepository : IRepository<RolesPermissionsModel>
    {
        DataTable GetViewRecordsByRoleId(int roleId);

        bool DeleteByRoleId(int roleId);
    }
}
