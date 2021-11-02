using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class CollectorReportModel
    {
        public int Id { get; set; }
        public int CoId { get; set; }
        public string ReportNo { get; set; }
        public DateTime Date { get; set; }
        public int Approved { get; set; }
        public int Fid { get; set; }
        public string status { get; set; }
        public string remarks { get; set; }
    }
}
