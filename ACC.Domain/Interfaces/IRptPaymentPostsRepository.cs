using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IRptPaymentPostsRepository : IRepository<RptPaymentPostsModel>
    {
        bool InsertWithRptTaxDues(RptPaymentPostsModel rptPaymentPostsModel, List<RptTaxDuesModel> rptTaxDuesModels);

        int GetLastInsertedID();
    }
}
