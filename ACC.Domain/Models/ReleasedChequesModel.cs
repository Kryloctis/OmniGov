using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class ReleasedChequesModel
    {
        public int ID { get; set; }
        public int RCIID { get; set; }
        public DateTime DateReleased { get; set; }
    }
}
