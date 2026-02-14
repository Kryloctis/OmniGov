namespace Accounting.Domain.Entities
{
    public class SubsidiaryLedgerAccountsModel
    {
        public int Id { get; set; }
        public byte FundId { get; set; }
        public ushort GeneralLedgerAccountsId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string ContactPerson { get; set; }

        public string Contact { get; set; }
    }
}