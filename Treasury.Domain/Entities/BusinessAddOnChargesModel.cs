namespace Treasury.Domain.Entities
{
    public class BusinessAddOnChargesModel
    {
        public int BusinessAddOnChargesID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsAppliedEachBusiness { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
