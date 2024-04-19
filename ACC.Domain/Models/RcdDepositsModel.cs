namespace ACC.Domain.Models
{
    internal class RcdDepositsModel
    {
        internal int Id { get; set; }
        internal RcdModel RcdModel { get; set; }
        internal BankDepositsModel BankDepositsModel { get; set; }
    }
}