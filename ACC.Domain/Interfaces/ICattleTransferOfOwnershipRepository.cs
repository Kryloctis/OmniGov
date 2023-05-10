using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface ICattleTransferOfOwnershipRepository : IAccRepository<CattleTransferOfOwnershipModel>
    {
        bool InsertWithCattleOwnershipPayment(CattleTransferOfOwnershipModel cattleTransferOfOwnershipModel);
    }
}
