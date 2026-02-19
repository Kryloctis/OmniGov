namespace OmniGov.Core.Entities
{
    public class FaceValueModel
    {
        public int id { get; set; }
        public int accountable_forms_id { get; set; }
        public DateTime facedate { get; set; }
        public decimal facevalue { get; set; }

        public bool isDefault { get; set; }
    }
}
