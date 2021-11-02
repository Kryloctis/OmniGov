using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class FaceValueModel
    {
        public int id { get; set; }
        public int accountable_forms_id { get; set; }
        public int faceyear { get; set; }
        public decimal facevalue { get; set; }
        public byte facedefault { get; set; }
    }
}
