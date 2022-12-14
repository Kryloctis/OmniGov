namespace ACC.Domain.Models
{
    public class SubMajorAccountGroupModel
    {
        public int Id { get; set; }
        public byte MajorAccountGroupId { get; set; }
        public string SubMajorAccountGroupCode { get; set; }
        public bool SubMajorAccountGroupName { get; set; }
    }
}