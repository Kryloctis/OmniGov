namespace OmniGov.Accounting.Domain.Entities
{
    public class ADADisbursementsJournalModel
    {
        public int Id { get; set; }
        public int JevId { get; set; }
        public string AdaNo { get; set; }
        public string DvNo { get; set; }
    }
}