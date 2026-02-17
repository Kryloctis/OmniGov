using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRptTaxDuesRepository : IRepository<RptTaxDuesModel>
    {
        DataTable GetViewRecordsByRptPaymentPostsId(int rptPaymentsId);

        bool BulkInsert(List<RptTaxDuesModel> entityList);
    }
}
