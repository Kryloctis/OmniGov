namespace Treasury.Domain.Entities
{
    public class PaymentCollectionHasChequesModel
    {
        public int PaymentCollectionId { get; set; }
        public int ChequesId { get; set; }
        public List<ChequesModel> ChequesModels { get; set; }
    }
}
