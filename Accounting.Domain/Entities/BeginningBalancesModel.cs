namespace Accounting.Domain.Entities
{
    public class BeginningBalancesModel
    {
        public int Id { get; set; }
        public byte FundsId { get; set; }
        public ushort GeneralLedgerId { get; set; }
        public ushort? SubsidiaryLedgerId { get; set; }
        public bool IsDebit { get; set; }
        public DateTime DateEntry { get; set; }
        public decimal Amount { get; set; }
    }
}