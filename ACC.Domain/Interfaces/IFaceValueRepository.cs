using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IFaceValueRepository:IAccRepository<FaceValueModel>
    {
        DataTable GetRecordsByAccountableFormId(int accountableFormId);
        decimal GetFaceValueByAccountableFormId(int id);
    }
}
