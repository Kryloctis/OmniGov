namespace ACC.Domain.Models
{
    public class GeneralCollectionsDepositsModel
    {
        public int Id { get; set; }
        public int GeneralCollectionId { get; set; }
        public int BankDepositId { get; set; }
    }
}