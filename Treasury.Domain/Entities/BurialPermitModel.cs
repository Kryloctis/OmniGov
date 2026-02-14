namespace Treasury.Domain.Entities
{
    public class BurialPermitModel
    {
        public int Id { get; set; }
        public int PaymentCollectionsId { get; set; }
        public int RemainsRegistryId { get; set; }
        public string Permission { get; set; }
        public int RemainsAge { get; set; }
        public DateTime DeathDate { get; set; }
        public string CauseOfDeath { get; set; }
        public string Cemetery { get; set; }
        public string Disinterment { get; set; }
        public bool IsInfectious { get; set; }
        public bool IsEmbalmed { get; set; }
        public string Disposition { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}