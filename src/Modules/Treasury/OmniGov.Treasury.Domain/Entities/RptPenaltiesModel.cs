namespace Treasury.Domain.Entities
{
    public class RptPenaltiesModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Frequency { get; set; }
        public decimal Rate { get; set; }
    }
}
