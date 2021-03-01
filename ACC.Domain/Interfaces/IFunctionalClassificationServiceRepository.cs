using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IFunctionalClassificationServiceRepository : IRepository<FunctionalClassificationServiceModel>
    {
        DataTable GetViewRecordsByClassificationId(byte id);
        bool CodeExist(string code);
        bool CodeExist(string code, int id);
        bool NameExist(string name);
        bool NameExist(string name, int id);
    }
}
