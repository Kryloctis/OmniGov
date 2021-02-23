using System;
using System.Collections.Generic;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IAccountGroupRepository : IRepository<AccountGroupModel>
    {
        bool CodeExist(string code);
        bool CodeExist(string code, int id);
        bool NameExist(string name);
        bool NameExist(string name, int id);
    }
}
