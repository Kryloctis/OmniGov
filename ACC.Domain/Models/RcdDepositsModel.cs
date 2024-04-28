namespace ACC.Domain.Models
{
    public class RcdDepositsModel
    {
        public int Id { get; set; }
        public RcdModel RcdModel { get; set; }
        public BankDepositsModel BankDepositsModel { get; set; }
    }
}