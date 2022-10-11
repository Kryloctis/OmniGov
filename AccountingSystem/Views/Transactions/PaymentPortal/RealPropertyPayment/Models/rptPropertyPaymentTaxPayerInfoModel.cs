using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem.Views.Transactions.PropertyPayment.Models
{
    public class rptPropertyPaymentTaxPayerInfoModel
    {
        public string TIN { get; set; }
        public string TaxPayerName { get; set; }
        public string BarangayName { get; set; }
        public string MunicipalityName { get; set; }
        public string ProvinceName { get; set; }
        public string Address { get; set; }
    }
}
