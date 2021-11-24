using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class GeneralCollectionPaymentsModel
    {
        public int Id { get; set; }
        public int CollectorsReportId { get; set; }
        public int GeneralCollectionsId { get; set; }
    }
}
