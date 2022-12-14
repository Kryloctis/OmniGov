using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IGeneralCollectionsDepositsRepository : IAccRepository<GeneralCollectionsDepositsModel>
    {
        DataTable GetCollectionsDepositsByRCDNo(string rcdNo);
    }
}