using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class CollectorReportModel
    {
        public int Id { get; set; }
        public int CollectorId { get; set; }
        public int? JobOrderId { get; set; }
        public string ReportNo { get; set; }
        public DateTime Date { get; set; }
        public sbyte IsApproved { get; set; }
        public sbyte IsDisapproved { get; set; }
        public int FundId { get; set; }
        public string Remarks { get; set; }
        public bool IsJO { get; set; }


    }
}
