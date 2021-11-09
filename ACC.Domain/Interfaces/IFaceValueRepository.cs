using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IFaceValueRepository:IRepository<FaceValueModel>
    {
        DataTable GetRecords(int id);
        bool SetDefault(int id);
        bool YearExist(int id, int year);

        decimal GetFaceValueByAccountableFormId(int id);
    }
}
