namespace Accounting.Domain.Entities
{
    public class JEVAccountsModel
    {
        public int Id { get; set; }
        public int JEVId { get; set; }
        public int? FPPId { get; set; }
        public ushort GeneralLedgerId { get; set; }
        public ushort? SubsidiaryLedgerId { get; set; }
        public string ObligationNo { get; set; }
        public bool? IsDeposit { get; set; }
        public bool IsDebit { get; set; }
        public decimal Amount { get; set; }
    }
}
