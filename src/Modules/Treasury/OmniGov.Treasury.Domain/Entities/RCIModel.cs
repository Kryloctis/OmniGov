namespace OmniGov.Treasury.Domain.Entities
{
    public class RciModel
    {
        public int Id { get; set; }
        public int ChequeID { get; set; }
        public int FundId { get; set; }
        public int FunctionProgramProjectId { get; set; }
        public string DVNo { get; set; }
        public string Payee { get; set; }
        public string NaturePayment { get; set; }
    }
}
