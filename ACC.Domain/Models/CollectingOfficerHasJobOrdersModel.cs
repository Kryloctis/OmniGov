using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class CollectingOfficerHasJobOrdersModel
    {
        public int CollectingOfficerId { get; set; }

        public int JobOrdersId { get; set; }
    }
}
