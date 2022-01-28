using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRCIObligationsRepository:IRepository<RCIObligationsModel>
    {

        DataTable GetRecordsByRCIId(int rciId);

        bool DeleteRecordsByRCIId(int rcidId);


    }
}
