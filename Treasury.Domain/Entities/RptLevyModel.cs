namespace Treasury.Domain.Entities
{
    public class RptLevyModel
    {
        public int Id { get; set; }
        public int RealPropertiesId { get; set; }
        public DateTime DateIssued { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
