using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class JournalsModel
    {
        public int Id { get; set; }
        public string JournalName { get; set; }
        public bool IsSpecialJournal { get; set; }
    }
}
