namespace Treasury.Domain.Entities
{
    public class RptTaxDuesModel
    {
        public int Id { get; set; }
        public int RptAssessmentPostId { get; set; }
        public int RptPaymentsId { get; set; }
        public decimal DiscountRate { get; set; }
        public bool IsAdvance { get; set; }
    }
}
