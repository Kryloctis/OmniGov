namespace ACC.Domain.Models
{
    public class AccountableFormsModel
    {
        public int Id { get; set; }
        public string AccFormNo { get; set; }
        public string AccFormDesc { get; set; }
        public bool IsCashTicket { get; set; }
    }
}