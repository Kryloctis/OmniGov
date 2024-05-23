using System;

namespace ACC.Domain.Models
{
    public class DelinquentNoticeModel
    {
        public int Id { get; set; }
        public int RealPropertiesId { get; set; }
        public string NoticeType { get; set; }
        public DateTime NoticeDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}