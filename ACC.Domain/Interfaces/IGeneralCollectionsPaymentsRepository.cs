using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IGeneralCollectionsPaymentsRepository:IAccRepository<GeneralCollectionPaymentsModel>
    {
        bool Append(List<GeneralCollectionPaymentsModel> entityList);

        DataTable GetRecordsByRCDNO(string RCDNo);

        DataTable GetCollectionPaymentByRCDNo(string rcdNo);
    }
}
