using OmniGov.Core.Interfaces;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRptPaymentRepository : IRepository<RptPaymentsModel>
    {
        bool InsertWithRptTaxDues(RptPaymentsModel rptPaymentModel, List<RptTaxDuesModel> rptTaxDuesModels);

        DataTable GetViewRecordsByDateTaxPayerName(DateTime dateFrom, DateTime dateTo, string taxPayerName);

        Dictionary<string, string> GetViewRecordById(int Id);

        int GetLastInsertedID(int createdBy);

        Dictionary<string, string> GetRecordByAssessmentPostId(int assessmentPostId);
    }
}