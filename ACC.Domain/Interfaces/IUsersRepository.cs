using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IUsersRepository : IAccRepository<UsersModel>
    {
        bool NameExist(string name);

        bool NameExist(string name, int id);

        Dictionary<string, string> GetUserRecordByAcc(string username, string password);

        bool UpdateWithPassword(UsersModel entity);

        bool AccIsValidated(string username, string password);

        DataTable GetLinksCollectingOfficers(string searchText);

        DataTable GetLinksDisbursingOfficers();

        DataTable GetLinksJOCollectingOfficers();

        DataTable GetViewRecordsBySearch(int rowLimit, string searchTxt);

        DataTable GetViewRecords();

        Dictionary<string, dynamic> GetViewRecordById(int Id);
    }
}