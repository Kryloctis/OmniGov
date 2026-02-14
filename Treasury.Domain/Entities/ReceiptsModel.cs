namespace Treasury.Domain.Entities
{
    public class ReceiptsModel
    {
        public int Id { get; set; }
        public int SerialNoFrom { get; set; }
        public int SerialNoTo { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }
        public int UserId { get; set; }
        public int AccountableFormId { get; set; }
    }
}