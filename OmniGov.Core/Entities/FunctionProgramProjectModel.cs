namespace OmniGov.Core.Entities
{
    public class FunctionProgramProjectModel
    {
        public int Id { get; set; }
        public int functionalClassificationServiceId { get; set; }
        public string FppCode { get; set; }
        public string FppName { get; set; }
        public bool IsSpecial { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}