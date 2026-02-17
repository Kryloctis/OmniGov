namespace Accounting.Domain.Entities
{
    public class JevModel
    {
        public int Id { get; set; }
        public byte FundsId { get; set; }
        public byte JournalsId { get; set; }
        public string TrnsctionNo { get; set; }
        public string JevNo { get; set; }
        public DateTime DateEntry { get; set; }
        public string RefNo { get; set; }
        public string Payee { get; set; }
        public string Explanation { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDisapproved { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsEdited { get; set; }
        public string Remarks { get; set; }
        public List<JEVAccountsModel> JEVAccountsModelList { get; set; }
        public byte CreatedBy { get; set; }
        public byte UpdatedBy { get; set; }
    }
}
