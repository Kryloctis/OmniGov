using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface ITaxTypesRepository : IAccRepository<TaxTypesModel>
    {
        DataTable GetParentNodesTaxTypes();

        DataTable GetChildNodesTaxTypes(int parentID);
        DataTable GetTaxTypeCodes();
        string GetParentCodeByID(int parentID);
    }
}
