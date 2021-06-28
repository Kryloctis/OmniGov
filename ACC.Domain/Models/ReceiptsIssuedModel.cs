using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class ReceiptsIssuedModel
    {

        public int Id { get; set; }
        public int CoId { get; set; }
        public int Is_returned { get; set; }
        public DateTime Returned_date { get; set; }
        public DateTime Issued { get; set; }
        public int RId { get; set; }
       
    }
}
