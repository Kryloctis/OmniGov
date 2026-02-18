namespace OmniGov.App.Views.Transactions.Payments.RealProperty.Models
{
    public class RptDetailedTaxDuesModel
    {
        public int AssessmentPostId { get; set; }
        public int Year { get; set; }
        public string CompleteArpNo { get; set; }
        public string TaxType { get; set; }
        public decimal TaxDue { get; set; }
        public decimal Discount { get; set; }
        public decimal Penalty { get; set; }
        public decimal TotalTaxDue { get; set; }
    }
}