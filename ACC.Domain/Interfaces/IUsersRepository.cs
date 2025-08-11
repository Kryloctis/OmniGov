using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IUsersRepository : IAccRepository<UsersModel>
    {
        bool HasPermission(byte userId, string permissionName);

        bool NameExist(string name);

        bool NameExist(string name, int id);

        byte ValidateLogin(string username, string password);

        bool UpdateWithPassword(UsersModel entity);

        Dictionary<string, string> GetUserByID(int Id);

        DataTable GetLinksCollectingOfficers(string searchText);

        DataTable GetLinksDisbursingOfficers();

        DataTable GetLinksJOCollectingOfficers();

        DataTable GetViewRecordsBySearch(int rowLimit, string searchTxt);

        Dictionary<string, dynamic> GetViewRecordById(int Id);
    }
}