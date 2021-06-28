using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class SubFPPModel
    {
        public int Id { get; set; }
        public int functionProgramProjectId { get; set; }
        public string othersFPPCode { get; set; }
        public string othersFPPName { get; set; }
    }
}
