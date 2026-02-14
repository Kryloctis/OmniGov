namespace Treasury.Domain.Entities
{
    public class TaxTypesModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public object ParentID { get; set; }
        public object FundID { get; set; }
        public string COAAccountCode { get; set; }
        public string BLGFAccountCode { get; set; }
        public bool IsDeleted { get; set; }
    }
}