using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IAccRepository<T> where T : class
    {
        bool IdExist(int id);
        DataTable GetRecords();
        DataTable GetRecordsBySearch(string searchText);
        Dictionary<string, string> GetRecordByID(int Id);
        int CountRecords();
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(List<T> entityList);
    }
}
