namespace ACC.Domain.Models
{
    public class ClassificationCodesModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsSpecial { get; set; }
    }
}