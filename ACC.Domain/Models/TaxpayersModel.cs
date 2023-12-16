using System;

namespace ACC.Domain.Models
{
    public class TaxpayersModel
    {
        public int Id { get; set; }
        public object RepresentativeRegistryId { get; set; }
        public string Tin { get; set; }
        public string Name { get; set; }
        public int TaxpayerTypeId { get; set; }
        public string Address { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string ContactInfo { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}