namespace ACC.Domain.Models
{
    public class BankAccountsModel
    {
        public int Id { get; set; }
        public BanksModel BanksModel { get; set; }

        public string AccountNumber { get; set; }
    }
}