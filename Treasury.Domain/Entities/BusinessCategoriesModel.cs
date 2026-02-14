namespace Treasury.Domain.Entities
{
    public class BusinessCategoriesModel
    {
        public int BusinessCategoryID { get; set; }
        public string Code { get; set; }
        public string OrdinanceReferenceNumber { get; set; }
        public string Description { get; set; }
        public bool LineOfBusiness { get; set; }
    }
}