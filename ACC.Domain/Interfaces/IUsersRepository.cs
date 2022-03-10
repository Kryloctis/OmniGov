using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;
namespace ACC.Domain.Interfaces
{
    public interface IUsersRepository : IRepository<UsersModel>
    {
        bool HasPermission(byte userId, string permissionName);
        bool NameExist(string name);

        bool NameExist(string name, int id);

        byte ValidateLogin(string username, string password);

        bool UpdateWithPassword(UsersModel entity);

        Dictionary<string, string> GetUserByID(int Id);

        DataTable GetLinksCollectingOfficers();

        DataTable GetLinksDisbursingOfficers();

        DataTable GetLinksJOCollectingOfficers();

        DataTable GetViewRecordsBySearch(string office, string searchTxt);

        DataTable GetViewRecords();
        bool LinkedJobOrder(int id);
        bool LinkedCollector(int id);

        bool LinkedDisburser(int id);

        string GetUserRole(int id);

        string GetCollectorByUserId(int id);

        string GetCollectorNameByUserId(int userId);

        string GetDisbursingByUserId(int id);

        DataTable GetViewRecordsByOffice(string office);

        Dictionary<string, dynamic> GetViewRecordById(int Id);
    }
}
