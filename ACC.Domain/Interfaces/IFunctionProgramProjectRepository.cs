using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IFunctionProgramProjectRepository : IRepository<FunctionProgramProjectModel>
    {
        DataTable GetViewRecordsByServiceNameId(byte id);
        bool CodeExist(string code);
        bool CodeExist(string code, int id);
        bool NameExist(string name);
        bool NameExist(string name, int id);
    }
}
