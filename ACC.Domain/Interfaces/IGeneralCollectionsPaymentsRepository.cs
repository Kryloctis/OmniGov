using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IGeneralCollectionsPaymentsRepository:IRepository<GeneralCollectionPaymentsModel>
    {
        bool Append(List<GeneralCollectionPaymentsModel> entityList);
    }
}
