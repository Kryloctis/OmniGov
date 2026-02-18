namespace Treasury.Domain.Entities
{
    public class BankDepositsModel
    {
        public int Id { get; set; }
        public int BankAccountsID { get; set; }
        public int FundId { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
