using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class PreferencesModel
    {
        public int Id { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public byte[] Emblem { get; set; }
    }
}