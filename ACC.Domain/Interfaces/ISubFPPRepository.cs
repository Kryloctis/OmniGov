using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ISubFPPRepository : IAccRepository<SubFPPModel>
    {
        bool NameExist(string name);

        bool NameExist(int id, string name);

        bool CodeExist(string otherFPPCode);

        bool CodeExist(int id, string otherFPPCode);

        DataTable GetRecordsByFPPId(int id);

        DataTable GetRecordsByFPPIdCodeName(int fppId, string searchTxt);

        DataTable GetRecorsByIDSearchCode(int id, string searchtxt);
    }
}