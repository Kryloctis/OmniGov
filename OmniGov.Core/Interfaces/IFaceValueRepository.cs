using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces
{
    public interface IFaceValueRepository : IRepository<FaceValueModel>
    {
        DataTable GetRecordsByAccountableFormId(int accountableFormId);

        decimal GetFaceValueByAccountableFormId(int id);
    }
}