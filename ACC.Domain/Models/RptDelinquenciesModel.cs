namespace ACC.Domain.Models
{
    public class RptDelinquenciesModel
    {
        public int Id { get; set; }

        public int RptAssessmentPostId { get; set; }

        public string DelinquenciesStatus { get; set; }

        public int CreatedBy { get; set; }

    }
}
