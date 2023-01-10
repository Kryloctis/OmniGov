using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IChequesRepository : IAccRepository<ChequesModel>
    {
        int GetLastInsertId();
    }
}