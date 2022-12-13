using System;

namespace ACC.Domain.Models
{
    public class FunctionalClassificationModel
    {
        public int Id { get; set; }
        public string SectorCode { get; set; }
        public string SectorName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}