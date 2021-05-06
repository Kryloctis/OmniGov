using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class DisbursingOfficerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
    }
}
