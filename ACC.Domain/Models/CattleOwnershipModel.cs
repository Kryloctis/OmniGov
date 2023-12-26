namespace ACC.Domain.Models
{
    public class CattleOwnershipModel
    {
        public int Id { get; set; }
        public PaymentCollectionsModel PaymentCollectionsModel { get; set; }
        public TaxpayersModel TaxpayersModel { get; set; }
        public string CattleName { get; set; }
        public string CattleSex { get; set; }
        public string CattleAge { get; set; }
        public string Description { get; set; }
        public decimal CattlePrice { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}