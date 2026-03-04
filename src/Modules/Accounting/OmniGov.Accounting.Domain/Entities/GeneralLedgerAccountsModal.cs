namespace OmniGov.Accounting.Domain.Entities
{
    public class GeneralLedgerAccountsModel
    {
        public int Id { get; set; }
        public short SubMajorAccountGroupId { get; set; }
        public string LedgerCode { get; set; }
        public string LedgerName { get; set; }
        public bool IsContraAccount { get; set; }
    }
}