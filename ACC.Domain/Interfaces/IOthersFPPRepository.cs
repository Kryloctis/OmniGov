using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IOthersFPPRepository : IRepository<OthersFPPModel>
    {
        bool NameExist(string name);
        bool NameExist(int id, string name);
    }
}
