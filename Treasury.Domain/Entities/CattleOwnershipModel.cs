namespace Treasury.Domain.Entities
{
    public class CattleOwnershipModel
    {
        public int Id { get; set; }
        public int PaymentCollectionId { get; set; }
        public int TaxpayerId { get; set; }
        public string CattleName { get; set; }
        public string CattleSex { get; set; }
        public int CattleAge { get; set; }
        public int CattleYears { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}