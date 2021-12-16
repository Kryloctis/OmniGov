namespace ACC.Domain.Models
{
    public class SignatoriesModel
    {
        int Id { get; set; }
        string Prefix { get; set; }
        string FirstName { get; set; }
        char MiddleInitial { get; set; }
        string LastName { get; set; }
        string Suffix { get; set; }
        string Title { get; set; }
    }
}
