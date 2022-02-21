namespace ACC.Domain.Models
{
   public class CollectingOfficerModel
    {
        public int Id { get; set; }

        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string JobTitle { get; set; }
        public int UserId { get; set; }
    }
}
