namespace Accounting.Domain.Entities
{
    public class CheckDisbursementsJournalModel
    {
        public int Id { get; set; }
        public int JevId { get; set; }
        public DateTime CheckDate { get; set; }
        public string CheckNo { get; set; }
        public string DVNo { get; set; }
        public string RCINo { get; set; }
    }
}