using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
   public class CollectingOfficerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitia { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
    }
}
