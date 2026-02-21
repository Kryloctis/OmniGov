namespace OmniGov.Treasury.Domain.Entities
{
    public class ReleasedChequesModel
    {
        public int ID { get; set; }
        public int RCIID { get; set; }
        public DateTime DateReleased { get; set; }
    }
}
