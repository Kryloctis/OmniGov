
namespace ACC.Domain.Models
{
    public class TaxpayersModel
    {
        public int Id { get; set; }
        public string Tin { get; set; }
        public string Name { get; set; }
        public int TaxpayerTypeId { get; set; }
        public string Street { get; set; }
        public string Barangay { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string ContactInfo { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
