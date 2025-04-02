namespace LFS.Views.Transactions.Payments.RealProperty.Models
{
    public class rptTaxDueBillReportModel
    {
        public string CompleteArpNo { get; set; }
        public string Kind { get; set; }
        public string Classification { get; set; }
        public string LotNo { get; set; }
        public string Location { get; set; }
        public int TaxYear { get; set; }
        public decimal Area { get; set; }
        public decimal AssessedValue { get; set; }
        public decimal BasicTax { get; set; }
        public decimal SefTax { get; set; }
        public decimal Discount { get; set; }
        public decimal Penalty { get; set; }
        public decimal netTaxDue { get; set; }
    }
}