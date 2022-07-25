using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.Domain.Models
{
    public class AssessmentPostingModel
    {
        public int Id { get; set; }
        public string ArpNo  { get; set; }
        public DateTime PostedAt { get; set; }
    }
}
