using System;

namespace ACC.Domain.Models
{
    internal class RcdModel
    {
        internal int Id { get; set; }
        internal FundsModel FundsModel { get; set; }
        internal string ReportNo { get; set; }
        internal DateTime Date { get; set; }
        internal UsersModel CreatedBy { get; set; }
        internal UsersModel UpdatedBy { get; set; }
    }
}