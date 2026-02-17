using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces.Repositories
{
    public interface IUsersRepository : IRepository<UsersModel>
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
