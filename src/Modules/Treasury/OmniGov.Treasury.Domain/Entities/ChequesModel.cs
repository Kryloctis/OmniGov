namespace Treasury.Domain.Entities
{
    public class ChequesModel
    {
        public int Id { get; set; }
        public int BankAccountsId { get; set; }
        public string ChequeNo { get; set; }
        public DateTime ChequeDate { get; set; }
        public decimal Amount { get; set; }
    }
}
