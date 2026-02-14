namespace Treasury.Domain.Entities
{
    public class CommunityTaxCertificateModel
    {
        public int Id { get; set; }
        public int PaymentCollectionsId { get; set; }
        public int Year { get; set; }
        public string PlaceOfIssued { get; set; }
        public DateTime DateOfIssued { get; set; }
        public string TIN { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool Sex { get; set; }
        public string Citizenship { get; set; }
        public string ICR { get; set; }
        public string CivilStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string Profession { get; set; }
        public decimal BasicCommunityTax { get; set; }
        public decimal AdditionalCommunityTax { get; set; }
        public int CreatedBy { get; set; }
    }
}