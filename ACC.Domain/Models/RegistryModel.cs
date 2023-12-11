using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACC.Domain.Models
{
    public class RegistryModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public string Street { get; set; }
        public string Barangay { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string ContactInfo { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}