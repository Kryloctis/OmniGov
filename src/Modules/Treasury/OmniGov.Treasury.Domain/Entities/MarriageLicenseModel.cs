namespace OmniGov.Treasury.Domain.Entities
{
    public class MarriageLicenseModel
    {
        public int Id { get; set; }
        public int PaymentCollectionsId { get; set; }
        public string RegistryNo { get; set; }
        public string MarriageLicenseNo { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DatePublished { get; set; }
        public int GroomRegistryId { get; set; }
        public int GroomAge { get; set; }
        public int GroomMonths { get; set; }
        public string GroomReligion { get; set; }
        public string GroomResidence { get; set; }
        public int BrideRegistryId { get; set; }
        public int BrideAge { get; set; }
        public int BrideMonths { get; set; }
        public string BrideReligion { get; set; }
        public string BrideResidence { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
