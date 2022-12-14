namespace AccountingSystem.Views.Transactions.PropertyPayment.Models
{
    public class rptConslidatedTaxDuesModel
    {
        public bool IsChecked { get; set; }
        public int Id { get; set; }
        public int Year { get; set; }
        public string CompleteArpNo { get; set; }
        public decimal AssessedValue { get; set; }
        public decimal TaxDue { get; set; }
        public decimal DiscountRate { get; set; }
        public bool DiscountIsAdvance { get; set; }
        public decimal Discount { get; set; }
        public decimal Penalty { get; set; }
        public decimal TotalTaxDue { get; set; }
    }
}