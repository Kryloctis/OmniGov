using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IMarriageLicenseRepository:IAccRepository<MarriageLicenseModel>
    {
        bool InsertWithMarriageLicensePayment(MarriageLicenseModel marriageLicenseModel);
    }
}
