using System;

namespace ACC.Domain.Models
{
    public class AllotmentReleaseModel
    {
        public int ID { get; set; }
        public string ARONumber { get; set; }
        public string Purpose { get; set; }
        public DateTime DateIssued { get; set; }
    }
}