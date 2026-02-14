namespace OmniGov.Core.Entities
{
    public class MajorAccountGroupModel
    {
        public int Id { get; set; }
        public byte AccountGroupId { get; set; }
        public string MajorAccountGroupCode { get; set; }
        public string MajorAccountGroupName { get; set; }
    }
}