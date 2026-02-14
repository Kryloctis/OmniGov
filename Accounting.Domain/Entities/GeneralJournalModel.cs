namespace Accounting.Domain.Entities
{
    public class GeneralJournalModel
    {
        public int Id { get; set; }
        public int JevId { get; set; }
        public string DVNo { get; set; }
        public string CheckNo { get; set; }
        public string ORNo { get; set; }
    }
}