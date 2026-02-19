using System.Data;

namespace OmniGov.Core.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        bool IdExist(int id);

        DataTable GetRecords();

        DataTable GetRecordsBySearch(string searchText);

        Dictionary<string, string> GetRecordByID(int Id);

        bool Insert(T entity);

        bool Update(T entity);

        bool Delete(List<T> entityList);
    }
}
