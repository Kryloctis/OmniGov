namespace ACC.Domain.Models
{
    public class BeginningBalancesModel
    {
        public int Id { get; set; }
        public byte FundsId { get; set; }
        public ushort GeneralLedgerId { get; set; }
        public ushort? SubsidiaryLedgerId { get; set; }
        public short Year { get; set; }
        public decimal Amount { get; set; }
    }
}
