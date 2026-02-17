namespace Accounting.Domain.Entities
{
    public class AmortizationScheduleModel
    {
        public int Id { get; set; }
        public int AmortizationId { get; set; }
        public DateTime Date { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal GRTAmount { get; set; }
    }
}
