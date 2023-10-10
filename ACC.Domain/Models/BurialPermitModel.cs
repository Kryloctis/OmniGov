using System;

namespace ACC.Domain.Models
{
    public class BurialPermitModel
    {
        public int ID { get; set; }
        public string Permission { get; set; }
        public string RemainsName { get; set; }
        public string RemainsNationality { get; set; }
        public int RemainsAge { get; set; }
        public string RemainsSex { get; set; }
        public DateTime DeathDate { get; set; }
        public string CauseOfDeath { get; set; }
        public string Cemetery { get; set; }
        public string Disinterment { get; set; }
        public bool IsInfectious { get; set; }
        public bool IsEmbalmed { get; set; }
        public string Disposition { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }




    }
}
