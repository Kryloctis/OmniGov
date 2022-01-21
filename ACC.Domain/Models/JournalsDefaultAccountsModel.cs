namespace ACC.Domain.Models
{
    public class JournalsDefaultAccountsModel
    {
        public int Id { get; set; }
        public int JournalId { get; set; }
        public int fundId { get; set; }
        public int AccountId { get; set; }

        public bool IsDebit { get; set; }
    }
}
