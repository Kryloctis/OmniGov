using System;

namespace ACC.Domain.Models
{
    public class RcdModel
    {
        public int Id { get; set; }
        public FundsModel FundsModel { get; set; }
        public string ReportNo { get; set; }
        public DateTime Date { get; set; }
        public UsersModel CreatedBy { get; set; }
        public UsersModel UpdatedBy { get; set; }
    }
}