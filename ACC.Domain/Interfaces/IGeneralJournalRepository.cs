using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IGeneralJournalRepository : IAccRepository<GeneralJournalModel>
    {
        bool UpdateByJevId(GeneralJournalModel entity);

        bool JevIdExist(int jevId);

        Dictionary<string, string> GetViewRecordByJevID(int jevId);

        bool DeleteGenJrnlJevId(int jevId);
    }
}