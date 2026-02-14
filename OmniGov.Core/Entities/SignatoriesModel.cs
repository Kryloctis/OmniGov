namespace OmniGov.Core.Entities
{
    public class SignatoriesModel
    {
        public int Id { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public char MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
    }
}