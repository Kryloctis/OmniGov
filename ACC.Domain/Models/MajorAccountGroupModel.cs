using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class MajorAccountGroupModel
    {
        public int Id { get; set; }
        public byte AccountGroupId { get; set; }
        public string MajorAccountGroupCode { get; set; }
        public bool MajorAccountGroupName { get; set; }
    }
}
