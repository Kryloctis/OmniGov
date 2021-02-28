using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
   public class FunctionProgramProjectModel
    {
        public int Id { get; set; }
        public int functionalClassificationServiceId { get; set; }
        public string FppCode { get; set; }
        public string FppName { get; set; }
    }
}
