using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IOthersFPPRepository : IRepository<OthersFPPModel>
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
