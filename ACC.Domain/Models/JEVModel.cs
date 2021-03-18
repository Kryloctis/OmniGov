using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class JEVModel
    {
        public uint Id { get; set; }
        public byte FundsId { get; set; }
        public byte JournalsId { get; set; }
        public string JEVNumber { get; set; }
        public DateTime DateEntry { get; set; }
        public string Explanation { get; set; }
        public List<JEVAccountsModel> JEVAccountsModelList { get; set; }
        public byte CreatedBy { get; set; }
        public byte UpdatedBy { get; set; }
    }
}
