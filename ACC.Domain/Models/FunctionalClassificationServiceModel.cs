using System;

namespace ACC.Domain.Models
{
    public class FunctionalClassificationServiceModel
    {
        public int Id { get; set; }
        public int functionalClassificationId { get; set; }
        public string ServiceName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}