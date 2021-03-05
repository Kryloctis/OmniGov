using System;
using System.Collections.Generic;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface ICollectingOfficerRepository : IRepository<CollectingOfficerModel>
    {       
        bool FullnameExist(string firstname, string middleinitial, string lastname, int id);        
    }
}
