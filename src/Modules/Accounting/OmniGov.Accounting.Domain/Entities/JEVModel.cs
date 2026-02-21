namespace OmniGov.Accounting.Domain.Entities
{
    public class JevModel
    {
        public int Id { get; set; }
        public byte FundsId { get; set; }
        public byte JournalsId { get; set; }

        public string TrnsctionNo { get; set; } = null!;

        public string? JevNo { get; set; }
        public DateTime DateEntry { get; set; }
        public string? RefNo { get; set; }
        public string? Payee { get; set; } = null!;
        public string? Explanation { get; set; }

        public enum Status
        { draft, pending, approved, disapproved, cancelled }

        public Status JevStatus { get; set; }

        public string? Remarks { get; set; }
        public byte IsEdited { get; set; }
        public byte CreatedBy { get; set; }
        public byte UpdatedBy { get; set; }
    }
}