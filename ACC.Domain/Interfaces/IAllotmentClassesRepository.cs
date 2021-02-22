using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IAllotmentClassesRepository : IRepository<AllotmentClassesModel>
    {

        bool NameExist(string name);
        bool NameExist(string name, int id);

        bool CodeExist(string code);

        bool CodeExist(string code, int id);
    }
}
