using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace ACC.Domain.Interfaces
{
    public interface IUsersRepository : IRepository<UsersModel>
    {
        bool HasPermission(byte userId, string permissionName);
        bool NameExist(string name);

        bool NameExist(string name, int id);

        byte ValidateLogin(string username, string password);

        bool UpdateWithPassword(UsersModel entity);
    }
}
