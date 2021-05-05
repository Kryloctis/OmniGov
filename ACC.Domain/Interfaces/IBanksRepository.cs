using System;
using System.Collections.Generic;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IBanksRepository : IRepository<BanksModel>
    {
        bool CodeExist(string code);
        bool CodeExist(string code, int id);
    }
}
