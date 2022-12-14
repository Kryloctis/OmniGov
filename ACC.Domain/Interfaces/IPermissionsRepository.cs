using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IPermissionsRepository : IAccRepository<PermissionsModel>
    {
        bool idExist(int id);

        bool NameExist(string name);

        bool NameExist(string name, int id);

        bool PermissionExists(int permissionId, int currentRoleId);

        DataTable GetRecordsByOffice(string officeName);
    }
}